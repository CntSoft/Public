using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Web.Mvc;

namespace VanChi.FMS.Web.Common
{
    #region Extend Display Attribute

    /// <summary>
    /// Extend Display Attribute
    /// </summary>
    public class ExDisplayAttribute : DisplayNameAttribute
    {
        string resourceId;
        string textVi;
        string textEn;
        public ExDisplayAttribute(Type type, string fieldName, string textVi, string textEn = "")
        {
            this.textVi = textVi;
            this.textEn = string.IsNullOrEmpty(textEn) ? fieldName : textEn;
            this.resourceId = ResourceManagement.GetResourceID(type, fieldName) + ".Display";
        }
        public override string DisplayName
        {
            get
            {
                return ResourceManagement.GetResourceText(resourceId, textVi, textEn);
            }
        }
    }

    #endregion

    #region Extend Remote Attribute

    /// <summary>
    /// Extend Remote Attribute
    /// </summary>
    public class ExRemoteAttribute : RemoteAttribute, IClientValidatable
    {
        string resourceId;
        string textVi;
        string textEn;
        public ExRemoteAttribute(string action, string controller, Type type, string fieldName, string errorMessageTextVi, string errorMessageTextEn = "")
            : base(action, controller)
        {
            this.textVi = errorMessageTextVi;
            this.textEn = string.IsNullOrEmpty(errorMessageTextEn) ? fieldName : errorMessageTextEn;
            this.resourceId = ResourceManagement.GetResourceID(type, fieldName) + ".RemoteErrorMessage";
            ErrorMessage = ResourceManagement.GetResourceText(resourceId, textVi, textEn);
        }
        public override string FormatErrorMessage(string name)
        {
            return ResourceManagement.GetResourceText(resourceId, textVi, textEn);
        }
    }

    #endregion

    #region Extend Required Attribute

    /// <summary>
    /// Extend Required Attribute
    /// </summary>
    public class RequiredAttributeAdapter : DataAnnotationsModelValidator<RequiredAttribute>
    {
        public RequiredAttributeAdapter(ModelMetadata metadata, ControllerContext context, RequiredAttribute attribute)
            : base(metadata, context, attribute)
        {
            attribute.ErrorMessage = ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_Required", "{0} không được bỏ trống", "{0} is required");
            if (string.IsNullOrEmpty(attribute.ErrorMessage) || attribute.ErrorMessage == "SystemResourceID.ErrorMessage_Required")
            {
                attribute.ErrorMessage = "{0} is required";
            }
        }
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRequiredRule(base.ErrorMessage);
            if (base.Attribute.AllowEmptyStrings)
            {
                rule.ValidationParameters["allowempty"] = "true";
            }
            return new ModelClientValidationRequiredRule[] { rule };
        }
    }

    #endregion

    #region Extand Email Attribute

    /// <summary>
    /// Extand Email Attribute
    /// </summary>
    public class ExEmailAttribute : RegularExpressionAttribute, IClientValidatable
    {
        public ExEmailAttribute()
            : base(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$")
        {
            this.ErrorMessage = ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_Email", "Email không hợp lệ", "Not a valid email");
        }
        public override string FormatErrorMessage(string name)
        {
            return ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_Email", "Email không hợp lệ", "Not a valid email");
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRegexRule(ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_Email", "Email không hợp lệ", "Not a valid email"), base.Pattern);
            return new[] { rule };
        }
    }

    #endregion

    #region Extend StringLength Attribute

    /// <summary>
    /// Extend StringLength Attribute
    /// </summary>
    public class ExStringLengthAttribute : StringLengthAttribute
    {
        int _maximumLength = 1000;
        string errorMessageMin = string.Empty;
        string errorMessageMax = string.Empty;
        public ExStringLengthAttribute(int maximumLength)
            : base(maximumLength)
        {
            _maximumLength = maximumLength;
        }
        public override bool IsValid(object value)
        {
            string val = Convert.ToString(value);
            if (val.Length < base.MinimumLength)
            {
                base.ErrorMessage = ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_StringLengthMin", "{0} phải có độ dài tối thiểu là {1}", "The field {0} must be a string with a minimum length of {1}");
                errorMessageMin = base.ErrorMessage;
                errorMessageMax = string.Empty;
            }
            if (val.Length > base.MaximumLength)
            {
                base.ErrorMessage = ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_StringLengthMax", "{0} chỉ cho phép độ dài tối đa là {1}", "The field {0} must be a string with a maximum length of {1}"); 
                errorMessageMax = base.ErrorMessage;
                errorMessageMin = string.Empty;
            }
            return base.IsValid(value);
        }
        public override string FormatErrorMessage(string name)
        {
            if (!string.IsNullOrEmpty(errorMessageMin))
            {
                return string.Format(errorMessageMin, name, base.MinimumLength);
            }
            else
            {
                return string.Format(errorMessageMax, name, _maximumLength);
            }
        }
    }

    #endregion

    #region Extend Range Attribute

    /// <summary>
    /// Extend Range Attribute
    /// </summary>
    public class ExRangeAttribute : RangeAttribute, IClientValidatable
    {
        double _min, _max;
        string defaultError = ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_StringRange", "{0} phải nằm giữa {1} và {2}", "{0} must be between {1} and {2}");
        public ExRangeAttribute(double minimum, double maximum)
            : base(minimum, maximum)
        {
            _min = minimum;
            _max = maximum;
            this.ErrorMessage = defaultError;
        }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_StringRange", "{0} phải nằm giữa {1} và {2}", "{0} must be between {1} and {2}"), name, _min, _max);
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.PropertyName),
                ValidationType = "range"
            };
            rule.ValidationParameters.Add("rangemin", Minimum);
            rule.ValidationParameters.Add("rangemax", Maximum);
            yield return rule;
        }
    }

    #endregion

    #region Integer Attribute

    /// <summary>
    /// Integer Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IntegerAttribute : DataTypeAttribute
    {
        public IntegerAttribute()
            : base("integer") { }
        public override string FormatErrorMessage(string name)
        {
            ErrorMessage = ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_Number", "{0} phải nhập số", "The field {0} must be a number");

            return base.FormatErrorMessage(name);
        }
        public override bool IsValid(object value)
        {
            if (value == null) return true;
            int retNum;
            return int.TryParse(Convert.ToString(value), out retNum);
        }
    }

    #endregion

    #region Extend Validation Attribute

    /// <summary>
    /// Extend Validation Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class ExValidationAttribute : ValidationAttribute
    {
        readonly string _contain;
        public ExValidationAttribute(string contain)
        {
            this._contain = contain;
            ErrorMessage = ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_NotContains", "{0} phải chứa '{1}'", "{0} must contains {1}");
        }
        public string Part
        {
            get { return _contain; }
        }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_NotContains", "{0} phải chứa '{1}'", "{0} must contains {1}"), name, _contain);
        }
        public override bool IsValid(object value)
        {
            if (value == null) return true;
            return value is string && Convert.ToString(value).Contains(_contain);
        }
    }

    #endregion

    #region Custom Validation Attribute

    /// <summary>
    /// Custom Validation Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true)]
    public sealed class CustomValidationAttribute : ValidationAttribute
    {
        #region Member Fields

        private Type _validatorType;
        private string _method;
        private MethodInfo _methodInfo;
        private bool _isSingleArgumentMethod;
        private string _lastMessage;
        private Type _valuesType;
        private Lazy<string> _malformedErrorMessage;
        #if !SILVERLIGHT
        private Tuple<string, Type> _typeId;
        #endif

        #endregion

        #region All Constructors

        /// <summary>
        /// Instantiates a custom validation attribute that will invoke a method in the
        /// specified type.
        /// </summary>
        /// <remarks>An invalid <paramref name="validatorType"/> or <paramref name="Method"/> will be cause
        /// <see cref="IsValid(object, ValidationContext)"/>> to return a <see cref="ValidationResult"/>
        /// and <see cref="ValidationAttribute.FormatErrorMessage"/> to return a summary error message.
        /// </remarks>
        /// <param name="validatorType">The type that will contain the method to invoke.  It cannot be null.  See <see cref="Method"/>.</param>
        /// <param name="method">The name of the method to invoke in <paramref name="validatorType"/>.</param>
        public CustomValidationAttribute(Type validatorType, string method)
            : base(ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_NotValid", "{0} không đúng định dạng", "The field {0} is not valid"))
        {
            this._validatorType = validatorType;
            this._method = method;
            _malformedErrorMessage = new Lazy<string>(CheckAttributeWellFormed);
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets the type that contains the validation method identified by <see cref="Method"/>.
        /// </summary>
        public Type ValidatorType
        {
            get
            {
                return this._validatorType;
            }
        }

        /// <summary>
        /// Gets the name of the method in <see cref="ValidatorType"/> to invoke to perform validation.
        /// </summary>
        public string Method
        {
            get
            {
                return this._method;
            }
        }

#if !SILVERLIGHT
        /// <summary>
        /// Gets a unique identifier for this attribute.
        /// </summary>
        public override object TypeId
        {
            get
            {
                if (_typeId == null)
                {
                    _typeId = new Tuple<string, Type>(this._method, this._validatorType);
                }
                return _typeId;
            }
        }
#endif

        #endregion

        /// <summary>
        /// Override of validation method.  See <see cref="ValidationAttribute.IsValid(object, ValidationContext)"/>.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">A <see cref="ValidationContext"/> instance that provides
        /// context about the validation operation, such as the object and member being validated.</param>
        /// <returns>Whatever the <see cref="Method"/> in <see cref="ValidatorType"/> returns.</returns>
        /// <exception cref="InvalidOperationException"> is thrown if the current attribute is malformed.</exception>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // If attribute is not valid, throw an exeption right away to inform the developer
            this.ThrowIfAttributeNotWellFormed();

            MethodInfo methodInfo = this._methodInfo;

            // If the value is not of the correct type and cannot be converted, fail
            // to indicate it is not acceptable.  The convention is that IsValid is merely a probe,
            // and clients are not expecting exceptions.
            object convertedValue;
            if (!this.TryConvertValue(value, out convertedValue))
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture,
                    ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_NotValid", "{0} không đúng định dạng", "The field {0} is not valid"),
                                                    (value != null ? value.GetType().ToString() : "null"), this._valuesType, this._validatorType, this._method));
            }

            // Invoke the method.  Catch TargetInvocationException merely to unwrap it.
            // Callers don't know Reflection is being used and will not typically see
            // the real exception
            try
            {
                // 1-parameter form is ValidationResult Method(object value)
                // 2-parameter form is ValidationResult Method(object value, ValidationContext context),
                object[] methodParams = this._isSingleArgumentMethod
                                            ? new object[] { convertedValue }
                                            : new object[] { convertedValue, validationContext };

                ValidationResult result = (ValidationResult)methodInfo.Invoke(null, methodParams);

                // We capture the message they provide us only in the event of failure,
                // otherwise we use the normal message supplied via the ctor
                this._lastMessage = null;

                if (result != null)
                {
                    this._lastMessage = result.ErrorMessage;
                }

                return result;
            }
            catch (TargetInvocationException tie)
            {
                if (tie.InnerException != null)
                {
                    throw tie.InnerException;
                }

                throw;
            }
        }

        /// <summary>
        /// Override of <see cref="ValidationAttribute.FormatErrorMessage"/>
        /// </summary>
        /// <param name="name">The name to include in the formatted string</param>
        /// <returns>A localized string to describe the problem.</returns>
        /// <exception cref="InvalidOperationException"> is thrown if the current attribute is malformed.</exception>
        public override string FormatErrorMessage(string name)
        {
            // If attribute is not valid, throw an exeption right away to inform the developer
            this.ThrowIfAttributeNotWellFormed();

            if (!string.IsNullOrEmpty(this._lastMessage))
            {
                return String.Format(CultureInfo.CurrentCulture, this._lastMessage, name);
            }

            // If success or they supplied no custom message, use normal base class behavior
            return base.FormatErrorMessage(name);
        }

        /// <summary>
        /// Checks whether the current attribute instance itself is valid for use.
        /// </summary>
        /// <returns>The error message why it is not well-formed, null if it is well-formed.</returns>
        private string CheckAttributeWellFormed()
        {
            return this.ValidateValidatorTypeParameter() ?? this.ValidateMethodParameter();
        }

        /// <summary>
        /// Internal helper to determine whether <see cref="ValidatorType"/> is legal for use.
        /// </summary>
        /// <returns><c>null</c> or the appropriate error message.</returns>
        private string ValidateValidatorTypeParameter()
        {
            if (this._validatorType == null)
            {
                ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_Required", "{0} không được bỏ trống", "{0} is required");
            }

            if (!this._validatorType.IsVisible)
            {
                return String.Format(CultureInfo.CurrentCulture, ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_AttributeMustBePublic", "{0} thuộc tính không được phép truy cập", "{0} attribute must be public"), this._validatorType.Name);
            }

            return null;
        }

        /// <summary>
        /// Internal helper to determine whether <see cref="Method"/> is legal for use.
        /// </summary>
        /// <returns><c>null</c> or the appropriate error message.</returns>
        private string ValidateMethodParameter()
        {
            if (String.IsNullOrEmpty(this._method))
            {
                return ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_Required", "{0} không được bỏ trống", "{0} is required");
            }

            // Named method must be public and static
            MethodInfo methodInfo = this._validatorType.GetMethod(this._method, BindingFlags.Public | BindingFlags.Static);
            if (methodInfo == null)
            {
                return String.Format(CultureInfo.CurrentCulture, ResourceManagement.GetResourceText("SystemResourceID.ErrorMessage_MethodNotFound", "{0} không tìm thấy.", "{0} method not found."), this._method, this._validatorType.Name);
            }

            // Method must return a ValidationResult
            if (methodInfo.ReturnType != typeof(ValidationResult))
            {
                return String.Format(CultureInfo.CurrentCulture, ResourceManagement.GetResourceText("SystemResourceID.MessageString.MustReturnValidationResult", "Phương thức phải được trả về {0}.", "Method must return validation result {0}."), this._method, this._validatorType.Name);
            }

            ParameterInfo[] parameterInfos = methodInfo.GetParameters();

            // Must declare at least one input parameter for the value and it cannot be ByRef
            if (parameterInfos.Length == 0 || parameterInfos[0].ParameterType.IsByRef)
            {
                return String.Format(CultureInfo.CurrentCulture, ResourceManagement.GetResourceText("SystemResourceID.MessageString.Signal", "Must declare at least one input parameter for the value and it cannot be ByRef", "Must declare at least one input parameter for the value and it cannot be ByRef"), this._method, this._validatorType.Name);
            }

            // We accept 2 forms:
            // 1-parameter form is ValidationResult Method(object value)
            // 2-parameter form is ValidationResult Method(object value, ValidationContext context),
            this._isSingleArgumentMethod = (parameterInfos.Length == 1);

            if (!this._isSingleArgumentMethod)
            {
                if ((parameterInfos.Length != 2) || (parameterInfos[1].ParameterType != typeof(ValidationContext)))
                {
                    return String.Format(CultureInfo.CurrentCulture, ResourceManagement.GetResourceText("SystemResourceID.MessageString.Signal", "Must declare at least one input parameter for the value and it cannot be ByRef", "Must declare at least one input parameter for the value and it cannot be ByRef"), this._method, this._validatorType.Name);
                }
            }

            this._methodInfo = methodInfo;
            this._valuesType = parameterInfos[0].ParameterType;
            return null;
        }

        /// <summary>
        /// Throws InvalidOperationException if the attribute is not valid.
        /// </summary>
        private void ThrowIfAttributeNotWellFormed()
        {
            string errorMessage = _malformedErrorMessage.Value;
            if (errorMessage != null)
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

        /// <summary>
        /// Attempts to convert the given value to the type needed to invoke the method for the current
        /// CustomValidationAttribute.
        /// </summary>
        /// <param name="value">The value to check/convert.</param>
        /// <param name="convertedValue">If successful, the converted (or copied) value.</param>
        /// <returns><c>true</c> if type value was already correct or was successfully converted.</returns>
        private bool TryConvertValue(object value, out object convertedValue)
        {
            convertedValue = null;
            Type t = this._valuesType;

            // Null is permitted for reference types or for Nullable<>'s only
            if (value == null)
            {
                if (t.IsValueType && (!t.IsGenericType || t.GetGenericTypeDefinition() != typeof(Nullable<>)))
                {
                    return false;
                }

                return true;    // convertedValue already null, which is correct for this case
            }

            // If the type is already legally assignable, we're good
            if (t.IsAssignableFrom(value.GetType()))
            {
                convertedValue = value;
                return true;
            }

            // Value is not the right type -- attempt a convert.
            // Any expected exception returns a false
            try
            {
                convertedValue = Convert.ChangeType(value, t, CultureInfo.CurrentCulture);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (InvalidCastException)
            {
                return false;
            }
            catch (NotSupportedException)
            {
                return false;
            }
        }
    }

    #endregion
}