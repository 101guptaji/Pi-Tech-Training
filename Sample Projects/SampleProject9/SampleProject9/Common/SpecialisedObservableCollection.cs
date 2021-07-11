using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using SampleProject9.Common.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Windows.Data;

namespace SampleProject9.Common
{
    /// <summary>
    /// Allows viewmodel control of a bound collection.
    /// </summary>
    /// <typeparam name="T">The item type.</typeparam>
    public class SpecialisedObservableCollection<T> : ObservableCollection<T>, INotifyCollectionRangeChanged<T>, ICleanup
    {
        #region Properties

        /// <summary>
        /// Gets the items count.
        /// </summary>
        /// <value>
        /// The items count.
        /// </value>
        public int ItemsCount
        {
            get { return this.Count; }
        }

        /// <summary>
        /// The _is initial load
        /// </summary>
        private bool _isInitialLoad = true;
        /// <summary>
        /// Gets or sets a value indicating whether this instance is initial load.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is initial load; otherwise, <c>false</c>.
        /// </value>
        public bool IsInitialLoad
        {
            get { return _isInitialLoad; }
            set { Set(() => IsInitialLoad, ref _isInitialLoad, value); }
        }

        /// <summary>
        /// Raised when the collection is changing.
        /// </summary>
        public event EventHandler<NotifyCollectionRangeChangedEventArgs<T>> CollectionRangeChanged = delegate { };

        /// <summary>
        /// The selected item count
        /// </summary>
        private int _selectedItemCount;

        /// <summary>
        /// Gets or sets the selected item count.
        /// </summary>
        /// <value>
        /// The selected item count.
        /// </value>
        public int SelectedItemCount
        {
            get { return _selectedItemCount; } //TODO - Punit : Need to change this to type cast into IMultiSelectItem.
            set { Set(() => SelectedItemCount, ref _selectedItemCount, value); }
        }

        private bool _suppressNotification;
        /// <summary>
        /// A flag that allows any changes to the collection to be suppressed.
        /// Used during the <see cref="AddRange"/> to prevent multiple collection change notification events being fired.
        /// When the value is false the collection change notification is fired.
        /// </summary>
        public bool SuppressNotification
        {
            get { return _suppressNotification; }
            set
            {
                if (!Equals(_suppressNotification, value))
                {
                    _suppressNotification = value;
                    OnSuppressNotificationChanged();
                }
            }
        }

        /// <summary>
        /// The cancelation token source
        /// </summary>
        private CancellationTokenSource _cancelationTokenSource;

        /// <summary>
        /// The id
        /// </summary>
        private readonly string _id;

        /// <summary>
        /// Unique reference for the view model.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string ID
        {
            get { return _id; }
        }

        /// <summary>
        /// The view
        /// </summary>
        private ICollectionView _view;

        /// <summary>
        /// This accesses the default view created by the WPF
        /// framework when a collection is bound to an items control.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        public ICollectionView View
        {
            get { return _view; }
        }

        /// <summary>
        /// The is busy count
        /// </summary>
        private int _isBusyCount;

        /// <summary>
        /// Gets the current IsBusy count
        /// </summary>
        /// <value>
        /// The is busy count.
        /// </value>
        public int IsBusyCount
        {
            get { return _isBusyCount; }
        }

        /// <summary>
        /// Gets a value that determines if the viewmodel is currently busy.
        /// </summary>
        public bool IsBusy
        {
            get { return _isBusyCount > 0; }
        }

        /// <summary>
        /// The is clean
        /// </summary>
        private bool _isClean;

        /// <summary>
        /// Gets a value that determines if <see cref="Cleanup"/> has been called.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is clean; otherwise, <c>false</c>.
        /// </value>
        public bool IsClean
        {
            get { return _isClean; }
        }

        /// <summary>
        /// Gets a value indicating whether the control is in design mode
        /// (running in Blend or Visual Studio).
        /// </summary>
        /// <returns>True if currently in design mode.</returns>
        protected bool IsInDesignMode
        {
            get { return ViewModelBase.IsInDesignModeStatic; }
        }

        /// <summary>
        /// The collection of items without any filtering or sorting.
        /// </summary>
        public IEnumerable<T> ItemsUnFiltered
        {
            get { return this.ToList(); }
        }

        /// <summary>
        /// The _filtered list
        /// </summary>
        private SpecialisedObservableCollection<T> _filteredList;

        /// <summary>
        /// Gets the filtered list.
        /// This is a collection reference to the subset of filtered items in this same collection
        /// </summary>
        /// <value>
        /// The filtered list.
        /// </value>
        public SpecialisedObservableCollection<T> FilteredList
        {
            get
            {
                return _filteredList;
            }
            private set
            {
                _filteredList = value;
                OnFilterChanged();
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// The default constructor for the SpecialisedObservableCollection.
        /// </summary>
        public SpecialisedObservableCollection()
        {
            _id = Guid.NewGuid().ToString();
            _view = CollectionViewSource.GetDefaultView(this);
            _filteredList = this;
        }

        /// <summary>
        /// Constructor that adds the items to the collection.
        /// </summary>
        /// <param name="items">The items to add to the collection.</param>
        public SpecialisedObservableCollection(IEnumerable<T> items)
            : base(items)
        {
            _id = Guid.NewGuid().ToString();
            _view = CollectionViewSource.GetDefaultView(this);
            _filteredList = this;
            SelectedItemCount = 0;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Refreshes the collectionview
        /// </summary>
        public virtual void Refresh()
        {
            View.Refresh();
        }

        /// <summary>
        /// Resets the collection.
        /// </summary>
        public virtual void Reset()
        {
            CleanupItems();
            Clear();
        }

        /// <summary>
        /// Increments a count that determines if the current viewmodel <see cref="IsBusy"/>
        /// </summary>
        public void AddIsBusy()
        {
            _isBusyCount++;
            OnIsBusyChanged();
        }

        /// <summary>
        /// Decrements a count that determines if the current viewmodel <see cref="IsBusy"/>
        /// </summary>
        public void RemoveIsBusy()
        {
            if (IsBusyCount > 0)
            {
                _isBusyCount--;
                OnIsBusyChanged();
            }
        }

        /// <summary>
        /// Clears the items collection and raises the <see cref="CollectionRangeChanged"/> event.
        /// </summary>
        protected override void ClearItems()
        {
            var items = this.ToList();
            base.ClearItems();
            OnCollectionRangeChanged(NotifyCollectionChangedAction.Remove, items);
        }

        /// <summary>
        /// A convinient method for setting a property.
        /// </summary>
        /// <returns>True if the value was set. False if the values were equal.</returns>
        protected bool Set<TProp>(Expression<Func<TProp>> propertyExpression, ref TProp field, TProp newValue)
        {
            if (EqualityComparer<TProp>.Default.Equals(field, newValue))
            {
                return false;
            }
            field = newValue;
            RaisePropertyChanged(propertyExpression);
            return true;
        }

        /// <summary>
        /// Called whenever <see cref="IsBusy"/> changes.
        /// </summary>
        protected virtual void OnIsBusyChanged()
        {
            RaisePropertyChanged(() => IsBusy);
        }

        /// <summary>
        /// Called when [filter changed].
        /// </summary>
        protected virtual void OnFilterChanged() { }


        /// <summary>
        /// Clears all busy counts and sets <see cref="IsBusy"/> to false.
        /// </summary>
        public void ClearIsBusy()
        {
            while (IsBusy)
            {
                RemoveIsBusy();
            }
        }

        /// <summary>
        /// Releases the current Cancellation Token.
        /// </summary>
        protected void ReleaseCurrentCancelationToken()
        {
            var source = _cancelationTokenSource;
            if (source != null && !source.IsCancellationRequested)
            {
                _cancelationTokenSource = null;
                source.Cancel(true);
                source.Dispose();
            }
        }

        /// <summary>
        /// Creates a new CancellationToken.
        /// </summary>
        /// <returns>A new cancellation token.</returns>
        protected CancellationToken CreateCurrentCancelationToken()
        {
            _cancelationTokenSource = new CancellationTokenSource();
            _cancelationTokenSource.Token.ThrowIfCancellationRequested();
            return _cancelationTokenSource.Token;
        }

        /// <summary>
        /// Retreives the current cancellation token if one exists and not cancelling.
        /// If one doesn't exists a new one is created.
        /// This can be used for updates that may be happening alongside refreshes.
        /// </summary>
        /// <returns>A cancellation token.</returns>
        protected CancellationToken GetCurrentCancellationToken()
        {
            var source = _cancelationTokenSource;
            if (source != null && !source.IsCancellationRequested)
            {
                return _cancelationTokenSource.Token;
            }
            return CreateCurrentCancelationToken();
        }

        /// <summary>
        /// Adds a range of items without raising a collection
        /// change after every add.
        /// </summary>
        /// <param name="list">The range of items to add.</param>
        /// <exception cref="ArgumentNullException">A null exception is thrown if the items are null.</exception>
        public virtual void AddRange(IEnumerable<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            var items = list.ToList();
            if (items.Any())
            {
                _suppressNotification = true;
                foreach (T item in items)
                {
                    Add(item);
                }
                _suppressNotification = false;
                OnCollectionRangeChanged(NotifyCollectionChangedAction.Add, items);
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        /// <summary>
        /// Removes a range of items without raising a collection
        /// change after every add.
        /// </summary>
        /// <param name="list">The range of items to remove.</param>
        /// <exception cref="ArgumentNullException">A null exception is thrown if the items are null.</exception>
        public virtual void RemoveRange(IEnumerable<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            _suppressNotification = true;
            var items = list.ToList();
            foreach (T item in items)
            {
                Remove(item);
            }
            _suppressNotification = false;
            OnCollectionRangeChanged(NotifyCollectionChangedAction.Remove, items);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Adds a range of items on the UI thread and calls <see cref="AddRange"/>.
        /// </summary>
        /// <param name="list">The range of items to add.</param>
        /// <exception cref="ArgumentNullException">A null exception is thrown if the items are null.</exception>
        public virtual void AddRangeOnUI(IEnumerable<T> list)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() => AddRange(list));
        }

        /// <summary>
        /// Filtereds the specified removed items.
        /// </summary>
        /// <param name="filtered">The filtered.</param>
        public void Filtered(IList filtered)
        {
            IList<T> viewModelsList = new List<T>();
            foreach (var filteredItem in filtered)
            {
                viewModelsList.Add((T)filteredItem);
            }
            FilteredList = new SpecialisedObservableCollection<T>(viewModelsList);
        }

        /// <summary>
        /// Called when <see cref="SuppressNotification"/> changes.
        /// If the value is false the collection change notification is raised.
        /// </summary>
        protected virtual void OnSuppressNotificationChanged()
        {
            if (!SuppressNotification)
            {
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        /// <summary>
        /// Raises a CollectionChanged event unless <see cref="SuppressNotification"/> is set to true.
        /// </summary>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!SuppressNotification)
            {
                base.OnCollectionChanged(e);
                RaisePropertyChanged(() => ItemsUnFiltered);
                RaisePropertyChanged(() => ItemsCount);
            }
        }

        /// <summary>
        /// Called when a range of items have changed in the collection.
        /// </summary>
        protected virtual void OnCollectionRangeChanged(NotifyCollectionChangedAction action, List<T> items)
        {
            var oldItems = action == NotifyCollectionChangedAction.Remove ? items : null;
            var newItems = action == NotifyCollectionChangedAction.Add ? items : null;
            CollectionRangeChanged(this, new NotifyCollectionRangeChangedEventArgs<T>(action, newItems, oldItems));
            RaisePropertyChanged(() => ItemsCount);
        }

        /// <summary>
        /// A type safe way to raise a property change notification.
        /// </summary>
        /// <example>
        /// The following example raises a change notifiaction on the property called IsFiltered.
        /// <code lang="C#" title="C#">
        /// RaisePropertyChanged(() => IsFiltered);
        /// </code>
        /// </example>
        /// <typeparam name="TC">The type of the property.</typeparam>
        /// <param name="propertyExpression">The property rainsing the changes.</param>
        protected virtual void RaisePropertyChanged<TC>(Expression<Func<TC>> propertyExpression)
        {
            var propertyName = GetPropertyName(propertyExpression);
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        /// <typeparam name="TProp">The type of the property.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <returns>Name of the property</returns>
        /// <exception cref="System.ArgumentNullException">propertyExpression</exception>
        /// <exception cref="System.ArgumentException">
        /// Invalid argument;propertyExpression
        /// or
        /// Argument is not a property;propertyExpression
        /// </exception>
        private static string GetPropertyName<TProp>(Expression<Func<TProp>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException("propertyExpression");
            }

            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Invalid argument", "propertyExpression");
            }

            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null)
            {
                throw new ArgumentException("Argument is not a property", "propertyExpression");
            }

            return propertyInfo.Name;
        }
        
        /// <summary>
        /// Iterates through the collection and calls cleanup
        /// on any item that implements <see cref="ICleanup"/>.
        /// Calls clear on the collection.
        /// </summary>
        public virtual void CleanupItems()
        {
            var items = this.Where(x => x != null).OfType<ICleanup>().ToList();
            foreach (var item in items)
            {
                item.Cleanup();
            }
        }

        /// <summary>
        /// Calls <see cref="CleanupItems"/> on the UI thread.
        /// </summary>
        public virtual void CleanupItemsOnUI()
        {
            DispatcherHelper.CheckBeginInvokeOnUI(CleanupItems);
        }

        /// <summary>
        /// Calls Clear on the UI thread.
        /// </summary>
        public virtual void ClearOnUI()
        {
            DispatcherHelper.CheckBeginInvokeOnUI(Clear);
        }

        #endregion

        #region Cleanup

        /// <summary>
        /// Cleans up the instance.
        /// </summary>
        public virtual void Cleanup()
        {
            CleanupItems();
            ClearItems();
            _view = null;
            _isClean = true;
            ReleaseCurrentCancelationToken();
            ClearIsBusy();
        }

        #endregion
    }
}
