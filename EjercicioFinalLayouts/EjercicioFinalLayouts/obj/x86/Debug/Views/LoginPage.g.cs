﻿#pragma checksum "C:\Users\aruiz\Documents\GitHub\DEINT\EjercicioFinalLayouts\EjercicioFinalLayouts\Views\LoginPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "18065438510F007D1305A6348651CA5F8B017567C5B8AADFBF1B383E1B91EB50"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EjercicioFinalLayouts.Views
{
    partial class LoginPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\LoginPage.xaml line 11
                {
                    this.scrollViewer = (global::Windows.UI.Xaml.Controls.ScrollViewer)(target);
                }
                break;
            case 3: // Views\LoginPage.xaml line 15
                {
                    this.AnchoSuperior500 = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 4: // Views\LoginPage.xaml line 26
                {
                    this.stackPanelTop = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 5: // Views\LoginPage.xaml line 41
                {
                    this.txtbUsuarioLogin = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 6: // Views\LoginPage.xaml line 42
                {
                    this.txtblErrorUsuarioLogin = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // Views\LoginPage.xaml line 46
                {
                    this.pswbContrasenhaLogin = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 8: // Views\LoginPage.xaml line 47
                {
                    this.txtblErrorPasswordLogin = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // Views\LoginPage.xaml line 55
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.Button_IniciarSesion;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

