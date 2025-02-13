﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Silver.CodeAnalysis.Cs {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Silver.CodeAnalysis.Cs.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Smart contract code must not be inside a namespace. See https://academy.stratisplatform.com/Architecture%20Reference/SmartContracts/smart-contracts-basic-theory.html#using-net-for-smart-contracts ..
        /// </summary>
        internal static string SC0001_Description {
            get {
                return ResourceManager.GetString("SC0001_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Namespace declaration not allowed in smart contract code.
        /// </summary>
        internal static string SC0001_MessageFormat {
            get {
                return ResourceManager.GetString("SC0001_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Namespace declaration not allowed.
        /// </summary>
        internal static string SC0001_Title {
            get {
                return ResourceManager.GetString("SC0001_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Types from namespace cannot be used here.
        /// </summary>
        internal static string SC0002_Description {
            get {
                return ResourceManager.GetString("SC0002_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Types from namespace {0} cannot be used in smart contract code.
        /// </summary>
        internal static string SC0002_MessageFormat {
            get {
                return ResourceManager.GetString("SC0002_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Namespace cannot be used here.
        /// </summary>
        internal static string SC0002_Title {
            get {
                return ResourceManager.GetString("SC0002_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Classes in smart contract code must inherit from Stratis.SmartContrsct.
        /// </summary>
        internal static string SC0003_Description {
            get {
                return ResourceManager.GetString("SC0003_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Class {0} must inherit from class Stratis.SmartContracts.SmartContract.
        /// </summary>
        internal static string SC0003_MessageFormat {
            get {
                return ResourceManager.GetString("SC0003_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Class must inherit from SmartContract class.
        /// </summary>
        internal static string SC0003_Title {
            get {
                return ResourceManager.GetString("SC0003_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The first parameter in a smart constructor must be of type ISmartContractState..
        /// </summary>
        internal static string SC0004_Description {
            get {
                return ResourceManager.GetString("SC0004_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter {0} must be of type ISmartContractState..
        /// </summary>
        internal static string SC0004_MessageFormat {
            get {
                return ResourceManager.GetString("SC0004_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter type not allowed.
        /// </summary>
        internal static string SC0004_Title {
            get {
                return ResourceManager.GetString("SC0004_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to New object creation of reference types is not allowed in smart contract code. See https://github.com/stratisproject/StratisFullNode/blob/master/Documentation/Features/SmartContracts/Clr-execution-and-validation.md.
        /// </summary>
        internal static string SC0005_Description {
            get {
                return ResourceManager.GetString("SC0005_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A new {0} object cannot be created here.
        /// </summary>
        internal static string SC0005_MessageFormat {
            get {
                return ResourceManager.GetString("SC0005_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to New object creation of reference type not allowed.
        /// </summary>
        internal static string SC0005_Title {
            get {
                return ResourceManager.GetString("SC0005_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Field declarations are not allowed in smart contract code. See https://github.com/stratisproject/StratisFullNode/blob/master/Documentation/Features/SmartContracts/Clr-execution-and-validation.md.
        /// </summary>
        internal static string SC0006_Description {
            get {
                return ResourceManager.GetString("SC0006_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A field declaration cannot be made here.
        /// </summary>
        internal static string SC0006_MessageFormat {
            get {
                return ResourceManager.GetString("SC0006_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Field declaration not allowed.
        /// </summary>
        internal static string SC0006_Title {
            get {
                return ResourceManager.GetString("SC0006_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only certain variable types can be used in smart contract code.
        /// </summary>
        internal static string SC0007_Description {
            get {
                return ResourceManager.GetString("SC0007_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot declare a variable of type {0} here.
        /// </summary>
        internal static string SC0007_MessageFormat {
            get {
                return ResourceManager.GetString("SC0007_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Variable declaration not allowed.
        /// </summary>
        internal static string SC0007_Title {
            get {
                return ResourceManager.GetString("SC0007_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Only certain types and members can be used in smart contract code.
        /// </summary>
        internal static string SC0008_Description {
            get {
                return ResourceManager.GetString("SC0008_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property {0} from type {1} cannot be used here.
        /// </summary>
        internal static string SC0008_MessageFormat {
            get {
                return ResourceManager.GetString("SC0008_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot use this property here.
        /// </summary>
        internal static string SC0008_Title {
            get {
                return ResourceManager.GetString("SC0008_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot use this method here.
        /// </summary>
        internal static string SC0009_Description {
            get {
                return ResourceManager.GetString("SC0009_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method {0} from type {1} cannot be used here.
        /// </summary>
        internal static string SC0009_MessageFormat {
            get {
                return ResourceManager.GetString("SC0009_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method invocation not allowed.
        /// </summary>
        internal static string SC0009_Title {
            get {
                return ResourceManager.GetString("SC0009_Title", resourceCulture);
            }
        }
    }
}
