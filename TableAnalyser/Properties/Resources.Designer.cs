﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TableAnalyser.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TableAnalyser.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to CSV Files|*.csv.
        /// </summary>
        internal static string _openFileDialog_Filter {
            get {
                return ResourceManager.GetString("_openFileDialog_Filter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Open CSV file for 29 variant.
        /// </summary>
        internal static string _openFileDialog_Title {
            get {
                return ResourceManager.GetString("_openFileDialog_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Open CSV file for 29 variant.
        /// </summary>
        internal static string _openFileDialogTitle {
            get {
                return ResourceManager.GetString("_openFileDialogTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have error while choosing: 
        ///.
        /// </summary>
        internal static string ChooseExceptionMessage {
            get {
                return ResourceManager.GetString("ChooseExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File saved at: .
        /// </summary>
        internal static string FileSave {
            get {
                return ResourceManager.GetString("FileSave", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Click on chart to activate it
        ///Then click to swap Ox and Oy.
        /// </summary>
        internal static string GraphViewChartClickHint {
            get {
                return ResourceManager.GetString("GraphViewChartClickHint", resourceCulture);
            }
        }
    }
}
