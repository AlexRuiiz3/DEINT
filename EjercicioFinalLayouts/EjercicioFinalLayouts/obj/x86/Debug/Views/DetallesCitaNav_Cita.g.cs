﻿#pragma checksum "C:\Users\AlexRuiz\Desktop\Ciclo DAM\Repositorios\DEINT\EjercicioFinalLayouts\EjercicioFinalLayouts\Views\DetallesCitaNav_Cita.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1BBB2F97D32D9F08E380DB9B113E535302BEDDC0E8F9C8E05EF3155E656955D2"
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
    partial class DetallesCitaNav_Cita : 
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
        private class DetallesCitaNav_Cita_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IDetallesCitaNav_Cita_Bindings
        {
            private global::EjercicioFinalLayouts.Views.DetallesCitaNav_Cita dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBlock obj3;
            private global::Windows.UI.Xaml.Controls.TextBlock obj4;
            private global::Windows.UI.Xaml.Controls.TextBlock obj5;
            private global::Windows.UI.Xaml.Controls.TextBlock obj6;
            private global::Windows.UI.Xaml.Controls.TextBlock obj7;
            private global::Windows.UI.Xaml.Controls.TextBlock obj8;
            private global::Windows.UI.Xaml.Controls.TextBlock obj9;
            private global::Windows.UI.Xaml.Controls.TextBlock obj10;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj3TextDisabled = false;
            private static bool isobj4TextDisabled = false;
            private static bool isobj5TextDisabled = false;
            private static bool isobj6TextDisabled = false;
            private static bool isobj7TextDisabled = false;
            private static bool isobj8TextDisabled = false;
            private static bool isobj9TextDisabled = false;
            private static bool isobj10TextDisabled = false;

            public DetallesCitaNav_Cita_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 41 && columnNumber == 53)
                {
                    isobj3TextDisabled = true;
                }
                else if (lineNumber == 42 && columnNumber == 53)
                {
                    isobj4TextDisabled = true;
                }
                else if (lineNumber == 43 && columnNumber == 53)
                {
                    isobj5TextDisabled = true;
                }
                else if (lineNumber == 44 && columnNumber == 53)
                {
                    isobj6TextDisabled = true;
                }
                else if (lineNumber == 45 && columnNumber == 53)
                {
                    isobj7TextDisabled = true;
                }
                else if (lineNumber == 46 && columnNumber == 73)
                {
                    isobj8TextDisabled = true;
                }
                else if (lineNumber == 36 && columnNumber == 55)
                {
                    isobj9TextDisabled = true;
                }
                else if (lineNumber == 31 && columnNumber == 55)
                {
                    isobj10TextDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3: // Views\DetallesCitaNav_Cita.xaml line 41
                        this.obj3 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 4: // Views\DetallesCitaNav_Cita.xaml line 42
                        this.obj4 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 5: // Views\DetallesCitaNav_Cita.xaml line 43
                        this.obj5 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 6: // Views\DetallesCitaNav_Cita.xaml line 44
                        this.obj6 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 7: // Views\DetallesCitaNav_Cita.xaml line 45
                        this.obj7 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 8: // Views\DetallesCitaNav_Cita.xaml line 46
                        this.obj8 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 9: // Views\DetallesCitaNav_Cita.xaml line 36
                        this.obj9 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                        break;
                    case 10: // Views\DetallesCitaNav_Cita.xaml line 31
                        this.obj10 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
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

            // IDetallesCitaNav_Cita_Bindings

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
                    this.dataRoot = (global::EjercicioFinalLayouts.Views.DetallesCitaNav_Cita)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::EjercicioFinalLayouts.Views.DetallesCitaNav_Cita obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_DetallesCitaNavCitaViewVM(obj.DetallesCitaNavCitaViewVM, phase);
                    }
                }
            }
            private void Update_DetallesCitaNavCitaViewVM(global::EjercicioFinalLayouts.ViewModels.DetallesCitaNavCitaViewVM obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_DetallesCitaNavCitaViewVM_Cita(obj.Cita, phase);
                        this.Update_DetallesCitaNavCitaViewVM_Telefono(obj.Telefono, phase);
                        this.Update_DetallesCitaNavCitaViewVM_NombreCliente(obj.NombreCliente, phase);
                    }
                }
            }
            private void Update_DetallesCitaNavCitaViewVM_Cita(global::Entidades.Cita obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_DetallesCitaNavCitaViewVM_Cita_DiaSemana(obj.DiaSemana, phase);
                        this.Update_DetallesCitaNavCitaViewVM_Cita_Dia(obj.Dia, phase);
                        this.Update_DetallesCitaNavCitaViewVM_Cita_Mes(obj.Mes, phase);
                        this.Update_DetallesCitaNavCitaViewVM_Cita_Horario(obj.Horario, phase);
                        this.Update_DetallesCitaNavCitaViewVM_Cita_CodigoPostal(obj.CodigoPostal, phase);
                        this.Update_DetallesCitaNavCitaViewVM_Cita_Direccion(obj.Direccion, phase);
                    }
                }
            }
            private void Update_DetallesCitaNavCitaViewVM_Cita_DiaSemana(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCitaNav_Cita.xaml line 41
                    if (!isobj3TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj3, obj, null);
                    }
                }
            }
            private void Update_DetallesCitaNavCitaViewVM_Cita_Dia(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCitaNav_Cita.xaml line 42
                    if (!isobj4TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj4, obj.ToString(), null);
                    }
                }
            }
            private void Update_DetallesCitaNavCitaViewVM_Cita_Mes(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCitaNav_Cita.xaml line 43
                    if (!isobj5TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj5, obj, null);
                    }
                }
            }
            private void Update_DetallesCitaNavCitaViewVM_Cita_Horario(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCitaNav_Cita.xaml line 44
                    if (!isobj6TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj6, obj, null);
                    }
                }
            }
            private void Update_DetallesCitaNavCitaViewVM_Cita_CodigoPostal(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCitaNav_Cita.xaml line 45
                    if (!isobj7TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj7, obj, null);
                    }
                }
            }
            private void Update_DetallesCitaNavCitaViewVM_Cita_Direccion(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCitaNav_Cita.xaml line 46
                    if (!isobj8TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj8, obj, null);
                    }
                }
            }
            private void Update_DetallesCitaNavCitaViewVM_Telefono(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCitaNav_Cita.xaml line 36
                    if (!isobj9TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj9, obj, null);
                    }
                }
            }
            private void Update_DetallesCitaNavCitaViewVM_NombreCliente(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Views\DetallesCitaNav_Cita.xaml line 31
                    if (!isobj10TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text(this.obj10, obj, null);
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
            case 2: // Views\DetallesCitaNav_Cita.xaml line 14
                {
                    this.GridInformacionCita = (global::Windows.UI.Xaml.Controls.Grid)(target);
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
            case 1: // Views\DetallesCitaNav_Cita.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    DetallesCitaNav_Cita_obj1_Bindings bindings = new DetallesCitaNav_Cita_obj1_Bindings();
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

