using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace SampleProject11.Common
{
    /// <summary>
    /// A base class for accesing common viewmodel base functionality.
    /// </summary>
    /// <seealso cref="GalaSoft.MvvmLight.ObservableObject" />
    /// <seealso cref="GalaSoft.MvvmLight.ICleanup" />
    /// <seealso cref="System.ComponentModel.IDataErrorInfo" />
    public abstract class BaseViewModel : ObservableObject, ICleanup, IDataErrorInfo
    {
        #region Properties
        /// <summary>
        /// The is validated
        /// </summary>
        private bool _isValidated;

        /// <summary>
        /// The validation rules
        /// </summary>
        private Dictionary<string, Func<string>> _validationRules = new Dictionary<string, Func<string>>();
        /// <summary>
        /// Used to add rules for validation on the client.
        /// </summary>
        /// <value>
        /// The validation rules.
        /// </value>
        public Dictionary<string, Func<string>> ValidationRules
        {
            get { return _validationRules; }
        }

        /// <summary>
        /// Checks each validation rule contained in <see cref="ValidationRules" />.
        /// If any return a string then returns false.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsValid
        {
            get { return ValidationRules == null || ValidationRules.Values.All(x => string.IsNullOrWhiteSpace(x())); }
        }

        /// <summary>
        /// The identifier
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
        /// <value>
        ///   <c>true</c> if this instance is busy; otherwise, <c>false</c>.
        /// </value>
        public bool IsBusy
        {
            get { return _isBusyCount > 0; }
        }

        /// <summary>
        /// The is dirty count
        /// </summary>
        private int _isDirtyCount;
        /// <summary>
        /// Gets the current IsDirty count
        /// </summary>
        /// <value>
        /// The is dirty count.
        /// </value>
        public int IsDirtyCount
        {
            get { return _isDirtyCount; }
        }

        /// <summary>
        /// Gets a value that determines if the viewmodel has changes.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is dirty; otherwise, <c>false</c>.
        /// </value>
        public bool IsDirty
        {
            get { return _isDirtyCount > 0; }
        }

        /// <summary>
        /// The is clean
        /// </summary>
        private bool _isClean;
        /// <summary>
        /// Gets a value that determines if <see cref="Cleanup" /> has been called.
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
        /// <value>
        /// <c>true</c> if this instance is in design mode; otherwise, <c>false</c>.
        /// </value>
        protected bool IsInDesignMode
        {
            get { return ViewModelBase.IsInDesignModeStatic; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// The default constructor for BaseViewModel.
        /// Registers the design time services if in design mode.
        /// </summary>
        protected BaseViewModel()
        {
            _id = Guid.NewGuid().ToString();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Increments a count that determines if the current viewmodel <see cref="IsBusy" />
        /// </summary>
        public void AddIsBusy()
        {
            _isBusyCount++;
            OnIsBusyChanged();
        }

        /// <summary>
        /// Decrements a count that determines if the current viewmodel <see cref="IsBusy" />
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
        /// Increments a count that determines if the current viewmodel <see cref="IsDirty" />
        /// </summary>
        public void AddIsDirty()
        {
            _isDirtyCount++;
            OnIsDirtyChanged();
        }

        /// <summary>
        /// Decrements a count that determines if the current viewmodel <see cref="IsDirty" />
        /// </summary>
        public void RemoveIsDirty()
        {
            if (IsDirtyCount > 0)
            {
                _isDirtyCount--;
                OnIsDirtyChanged();
            }
        }

        /// <summary>
        /// Clears all busy counts and sets <see cref="IsBusy" /> to false.
        /// </summary>
        public void ClearIsBusy()
        {
            while (IsBusy)
            {
                RemoveIsBusy();
            }
        }

        /// <summary>
        /// Clears all dirty counts and sets <see cref="IsDirty" /> to false.
        /// </summary>
        public void ClearIsDirty()
        {
            while (IsDirty)
            {
                RemoveIsDirty();
            }
        }

        /// <summary>
        /// Adds a validation rules to the viewmodel.
        /// This can be used to create a rule when needed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="message">The message.</param>
        public void AddPropertyValidation<T>(Expression<Func<T>> propertyExpression, Func<string> message)
        {
            if (ValidationRules != null)
            {
                ValidationRules.Add(GetPropertyName(propertyExpression), message);
                RaisePropertyChanged(propertyExpression);
            }
        }

        /// <summary>
        /// Removes a validation rule from the viewmodel.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        public void RemovePropertyValidation<T>(Expression<Func<T>> propertyExpression)
        {
            if (ValidationRules != null)
            {
                var prop = GetPropertyName(propertyExpression);
                if (ValidationRules.ContainsKey(prop))
                {
                    ValidationRules.Remove(prop);
                    RaisePropertyChanged(propertyExpression);
                }
            }
        }
        #endregion

        #region Overridable Methods
        /// <summary>
        /// Used in validation. By default the <see cref="ValidationRules" /> field is
        /// used to check a field.
        /// </summary>
        /// <param name="columnName">The name of the field that has changed.</param>
        /// <returns>
        /// The error if one exists.
        /// </returns>
        public virtual string this[string columnName]
        {
            get
            {
                if (ValidationRules != null && _isValidated && ValidationRules.ContainsKey(columnName))
                {
                    return ValidationRules[columnName]();
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the combined error messages.
        /// </summary>
        public virtual string Error
        {
            get
            {
                if (ValidationRules != null && ValidationRules.Any() && _isValidated)
                {
                    var error = ValidationRules.Aggregate("", (current, rule) => { var ruleError = rule.Value(); return string.IsNullOrWhiteSpace(ruleError) ? current : current + Environment.NewLine + ruleError; });
                    return error.Trim();
                }
                return "";
            }
        }

        /// <summary>
        /// Called whenever <see cref="IsBusy" /> changes.
        /// </summary>
        protected virtual void OnIsBusyChanged()
        {
            RaisePropertyChanged(() => IsBusy);
        }

        /// <summary>
        /// Called whenever <see cref="IsDirty" /> changes.
        /// </summary>
        protected virtual void OnIsDirtyChanged()
        {
            RaisePropertyChanged(() => IsDirty);
        }

        /// <summary>
        /// Override this to validate the entity. This will be called before a save operation.
        /// By default the <see cref="ValidationRules" /> are checked.
        /// </summary>
        /// <returns>
        /// True if the entity is valid.
        /// </returns>
        public virtual bool Validate()
        {
            _isValidated = true;
            var isValid = true;
            if (ValidationRules != null)
            {
                foreach (var rule in ValidationRules.ToList())
                {
                    RaisePropertyChanged(rule.Key);
                    isValid = isValid && string.IsNullOrWhiteSpace(rule.Value());
                }
            }
            return isValid;
        }
        #endregion

        #region Cleanup
        /// <summary>
        /// Cleans up the instance resources.
        /// <para>
        /// To cleanup additional resources, override this method, clean up and then call base.Cleanup().
        /// </para>
        /// </summary>
        public virtual void Cleanup()
        {
            _isClean = true;
            ClearIsBusy();
            ClearIsDirty();
            _validationRules = null;
        }
        #endregion
    }
}
