Imports CapaLogica
Imports System.Data.Odbc

Public Class FormularioChat
    Private Sub BtnEnviar_Click(sender As Object, e As EventArgs) Handles BtnEnviar.Click

        ControladorMensaje.Guardar(txtSesion.Text, TxtId.Text, txtPara.Text, RTxtMensaje.Text)
        RTxtChat.Text += Environment.NewLine + "YO:" + Environment.NewLine + RTxtMensaje.Text
        WebBrowser1.DocumentText +=
            "
                <br />
                <b>YO: </b> 
                <br / >
                " + RTxtMensaje.Text + " 
            "
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Pooling.Tick
        'Dim lector As OdbcDataReader
        Dim tabla As New DataTable
        tabla = ControladorMensaje.BuscarMensajeNoLeido(txtSesion.Text, TxtId.Text)

        'tabla.Load(ControladorMensaje.BuscarMensajeNoLeido(txtSesion.Text, TxtId.Text))

        If tabla.Rows.Count > 0 Then

            For Each fila As DataRow In tabla.Rows
                RTxtChat.Text += Environment.NewLine + fila("emisor").ToString + " - " + fila("fechahora").ToString + Environment.NewLine + fila("texto").ToString

                WebBrowser1.DocumentText +=
            "
                <br />
                <b>" + fila("emisor") + " a las " + fila("fechahora") + " escribio: </b>
                <br />
                " + fila("texto") + " 
                <br />            
                "
                ControladorMensaje.MarcarMensajeLeido(fila("id_mensaje").ToString)
            Next

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Pooling.Enabled = True

    End Sub

    Private Sub FormularioChat_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
