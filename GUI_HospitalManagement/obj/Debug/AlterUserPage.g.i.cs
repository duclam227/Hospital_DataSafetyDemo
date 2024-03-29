﻿#pragma checksum "..\..\AlterUserPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2B96DE8FA052D320AFA282E5C99DD5FE95235DD532AC0900776609F3C3BB1F81"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GUI_HospitalManagement;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Expression.Media;
using HandyControl.Expression.Shapes;
using HandyControl.Interactivity;
using HandyControl.Media.Animation;
using HandyControl.Media.Effects;
using HandyControl.Properties.Langs;
using HandyControl.Themes;
using HandyControl.Tools;
using HandyControl.Tools.Converter;
using HandyControl.Tools.Extension;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GUI_HospitalManagement {
    
    
    /// <summary>
    /// AlterUserPage
    /// </summary>
    public partial class AlterUserPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\AlterUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridView;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\AlterUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TableList_ComboBox;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\AlterUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PrivList_ComboBox;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\AlterUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CheckBox_GrantOption;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\AlterUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_GrantPriv;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\AlterUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_RevokePriv;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\AlterUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_GrantColPriv;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\AlterUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_ShowPrivDetail;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GUI_HospitalManagement;component/alteruserpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AlterUserPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\AlterUserPage.xaml"
            ((GUI_HospitalManagement.AlterUserPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DataGridView = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.TableList_ComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.PrivList_ComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.CheckBox_GrantOption = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.Btn_GrantPriv = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\AlterUserPage.xaml"
            this.Btn_GrantPriv.Click += new System.Windows.RoutedEventHandler(this.Btn_Grant_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Btn_RevokePriv = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\AlterUserPage.xaml"
            this.Btn_RevokePriv.Click += new System.Windows.RoutedEventHandler(this.Btn_Revoke_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Btn_GrantColPriv = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\AlterUserPage.xaml"
            this.Btn_GrantColPriv.Click += new System.Windows.RoutedEventHandler(this.Btn_GrantColPriv_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Btn_ShowPrivDetail = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\AlterUserPage.xaml"
            this.Btn_ShowPrivDetail.Click += new System.Windows.RoutedEventHandler(this.Btn_ShowPrivDetail_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

