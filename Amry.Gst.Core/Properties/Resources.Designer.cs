﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Amry.Gst.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Amry.Gst.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Business Name query must be more than 3 characters.
        /// </summary>
        internal static string BusinessNameTooShortValidationMessage {
            get {
                return ResourceManager.GetString("BusinessNameTooShortValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Business Registration Number should only consist of digits, letters or dashes.
        /// </summary>
        internal static string InvalidBusinessRegNumberValidationMessage {
            get {
                return ResourceManager.GetString("InvalidBusinessRegNumberValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to GST Number query must consist of 12 digits.
        /// </summary>
        internal static string InvalidGstNumberValidationMessage {
            get {
                return ResourceManager.GetString("InvalidGstNumberValidationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Customs&apos; server did not return expected token.
        /// </summary>
        internal static string NoTokenReturnedErrorMessage {
            get {
                return ResourceManager.GetString("NoTokenReturnedErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Over 100 Results Returned. Please Narrow Search..
        /// </summary>
        internal static string Over100ResultsErrorMessage {
            get {
                return ResourceManager.GetString("Over100ResultsErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A single instance of GstWebScraper is not thread-safe and can only do one lookup at a time..
        /// </summary>
        internal static string SingleLookupErrorMessage {
            get {
                return ResourceManager.GetString("SingleLookupErrorMessage", resourceCulture);
            }
        }
    }
}
