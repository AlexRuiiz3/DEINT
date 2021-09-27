Imports MisClases

Public Class HolaMundo

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click



    End Sub

    Private Sub HolaMundo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim name As String
        Dim oPersona As ClsPersona 'oPersona con la o para indicar que es un objeto 

        If CajaTexto.Text.Equals("") Then
            MessageBox.Show("Defina un nombre")
        Else
            oPersona = New ClsPersona(CajaTexto.Text)
            MessageBox.Show("Hola " + oPersona.Nombre)
        End If


        'otra forma MsgBox("Hola " + name)'

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles CajaTexto.TextChanged

    End Sub
End Class
