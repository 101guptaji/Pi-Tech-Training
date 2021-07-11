using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace SampleProject8.Common.Services
{
    /// <summary>
    /// An interface used to notify when a range of items are added or removed on a collection.
    /// </summary>
    public interface INotifyCollectionRangeChanged<T> : IEnumerable<T>
    {
        /// <summary>
        /// Raised when a range of items have been added or removed in a collection.
        /// </summary>
        event EventHandler<NotifyCollectionRangeChangedEventArgs<T>> CollectionRangeChanged;
    }

    /// <summary>
    /// The event args raised on collections implementing INotifyCollectionRangeChanged.
    /// </summary>
    public class NotifyCollectionRangeChangedEventArgs<T> : EventArgs
    {
        #region Properties
        private readonly NotifyCollectionChangedAction _action;
        /// <summary>
        /// The change action.
        /// </summary>
        public NotifyCollectionChangedAction Action
        {
            get { return _action; }
        }

        private readonly List<T> _newItems;
        /// <summary>
        /// The new items added or removed.
        /// </summary>
        public List<T> NewItems
        {
            get { return _newItems; }
        }

        private readonly List<T> _oldItems;
        /// <summary>
        /// The old items added or removed.
        /// </summary>
        public List<T> OldItems
        {
            get { return _oldItems; }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor for NotifyCollectionChangingEventArgs.
        /// </summary>
        /// <param name="action">The change action.</param>
        /// <param name="newItems">The new items added or removed.</param>
        /// /// <param name="oldItems">The old items added or removed.</param>
        public NotifyCollectionRangeChangedEventArgs(NotifyCollectionChangedAction action, List<T> newItems, List<T> oldItems)
        {
            _action = action;
            _newItems = newItems;
            _oldItems = oldItems;
        }
        #endregion
    }
}

