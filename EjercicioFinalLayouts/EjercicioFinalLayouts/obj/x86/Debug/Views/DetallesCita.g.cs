﻿#pragma checksum "C:\Users\AlexRuiz\Desktop\Ciclo DAM\Repositorios\DEINT\EjercicioFinalLayouts\EjercicioFinalLayouts\Views\DetallesCita.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6A4E6BEF922A748BEB202F0D6FC27249144CD020A3AEC766E8DB0E2E841B5CBC"
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
    partial class DetallesCita : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class DetallesCita_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IDetallesCita_Bindings
        {
            private global::EjercicioFinalLayouts.Views.DetallesCita dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBlock obj11;
            private global::Windows.UI.Xaml.Controls.TextBlock obj12;
            private global::Windows.UI.Xaml.Controls.TextBlock obj13;
            private global::Windows.UI.Xaml.Controls.TextBlock obj14;
            private global::Windows.UI.Xaml.Controls.TextBlock obj15;
            private global::Windows.UI.Xaml.Controls.TextBlock obj16;
            private global::Windows.UI.Xaml.Controls.TextBlock obj17;
            private global::Windows.UI.Xaml.Controls.TextBlock obj18;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj11TextDisabled = false;
            private static bool isobj12TextDisabled = false;
            private static bool isobj13TextDisabled = false;
            private static bool isobj14TextDisabled = false;
            private static bool isobj15TextDisabled = false;
            private static bool isobj16TextDisabled = false;
            private static bool isobj17TextDisabled = false;
            private static bool isobj18TextDisabled = false;

            public DetallesCita_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 43 && columnNumber == 61)
                {
                    isobj11TextDisabled = true;
                }
                else if (lineNumber == 44 && columnNumber == 61)
                {
                    isobj12TextDisabled = true;
                }
                else if (lineNumber == 49 && columnNumber == 61)
                {
                    isobj13TextDisabled = true;
                }
                else if (lineNumber == 50 && columnNumber == 61)
                {
                    isobj14TextDisabled = true;
                }
                else if (lineNumber == 51 && columnNumber == 61)
                {
                    isobj15TextDisabled = true;
                }
                else if (lineNumber == 52 && columnNumber == 61)
                {
                    isobj16TextDisabled = true;
                }
                else if (lineNumber == 53 && columnNumber == 61)
                {
                    isobj17TextDisabled = true;
                }
                else if (lineNumber == 54 && columnNumber == 61)
                {
                    isobj18TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 11: // Views\DetallesCita.xaml line 43
                        this.obj11 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 12: // Views\DetallesCita.xaml line 44
                        this.obj12 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 13: // Views\DetallesCita.xaml line 49
                        this.obj13 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 14: // Views\DetallesCita.xaml line 50
                        this.obj14 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 15: // Views\DetallesCita.xaml line 51
                        this.obj15 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 16: // Views\DetallesCita.xaml line 52
                        this.obj16 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 17: // Views\DetallesCita.xaml line 53
                        this.obj17 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 18: // Views\DetallesCita.xaml line 54
                        this.obj18 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IDetallesCita_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::EjercicioFinalLayouts.Views.DetallesCita)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::EjercicioFinalLayouts.Views.DetallesCita obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_DetallesCitaViewVM(obj.DetallesCitaViewVM, phase);
                    }
                }
            }
            private void Update_DetallesCitaViewVM(global::EjercicioFinalLayouts.ViewModels.DetallesCitaViewVM obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_DetallesCitaViewVM_NombreCliente(obj.NombreCliente, phase);
                        this.Update_DetallesCitaViewVM_Telefono(obj.Telefono, phase);
                        this.Update_DetallesCitaViewVM_Cita(obj.Cita, phase);
                    }
                }
            }
            private void Update_DetallesCitaViewVM_NombreCliente(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCita.xaml line 43
                    if (!isobj11TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj11, obj, null);
                    }
                }
            }
            private void Update_DetallesCitaViewVM_Telefono(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCita.xaml line 44
                    if (!isobj12TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj12, obj, null);
                    }
                }
            }
            private void Update_DetallesCitaViewVM_Cita(global::Entidades.Cita obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_DetallesCitaViewVM_Cita_DiaSemana(obj.DiaSemana, phase);
                        this.Update_DetallesCitaViewVM_Cita_Dia(obj.Dia, phase);
                        this.Update_DetallesCitaViewVM_Cita_Mes(obj.Mes, phase);
                        this.Update_DetallesCitaViewVM_Cita_Horario(obj.Horario, phase);
                        this.Update_DetallesCitaViewVM_Cita_Direccion(obj.Direccion, phase);
                        this.Update_DetallesCitaViewVM_Cita_CodigoPostal(obj.CodigoPostal, phase);
                    }
                }
            }
            private void Update_DetallesCitaViewVM_Cita_DiaSemana(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCita.xaml line 49
                    if (!isobj13TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj13, obj, null);
                    }
                }
            }
            private void Update_DetallesCitaViewVM_Cita_Dia(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCita.xaml line 50
                    if (!isobj14TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj14, obj.ToString(), null);
                    }
                }
            }
            private void Update_DetallesCitaViewVM_Cita_Mes(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCita.xaml line 51
                    if (!isobj15TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj15, obj, null);
                    }
                }
            }
            private void Update_DetallesCitaViewVM_Cita_Horario(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCita.xaml line 52
                    if (!isobj16TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj16, obj, null);
                    }
                }
            }
            private void Update_DetallesCitaViewVM_Cita_Direccion(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCita.xaml line 53
                    if (!isobj17TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj17, obj, null);
                    }
                }
            }
            private void Update_DetallesCitaViewVM_Cita_CodigoPostal(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCita.xaml line 54
                    if (!isobj18TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj18, obj, null);
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\DetallesCita.xaml line 15
                {
                    this.stackTop = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3: // Views\DetallesCita.xaml line 82
                {
                    this.stackBelow = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // Views\DetallesCita.xaml line 83
                {
                    this.txtBNumeroNotificaciones = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // Views\DetallesCita.xaml line 78
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.Button_EnviarInforme;
                }
                break;
            case 6: // Views\DetallesCita.xaml line 66
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.Button_IncluirFotos;
                }
                break;
            case 7: // Views\DetallesCita.xaml line 67
                {
                    this.txtbFotosIncluidas = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // Views\DetallesCita.xaml line 68
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.Button_EliminarFotos;
                }
                break;
            case 9: // Views\DetallesCita.xaml line 60
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.Button_SeleccionarFotos;
                }
                break;
            case 10: // Views\DetallesCita.xaml line 63
                {
                    this.ListaFotos = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 19: // Views\DetallesCita.xaml line 22
                {
                    this.txtBNombreUsuario = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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
            switch(connectionId)
            {
            case 1: // Views\DetallesCita.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    DetallesCita_obj1_Bindings bindings = new DetallesCita_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

