Public Class Form1
    Dim Jogadas(12) As Integer
    Dim Matriz(12) As Integer
    Dim Quadros() As PictureBox
    Dim Anterior, Passo As Integer
    Sub imagens(quadro)
        Dim fig As New PictureBox
        Select Case Matriz(quadro)
            Case 0 : fig.BackgroundImage = My.Resources.bayern
            Case 1 : fig.BackgroundImage = My.Resources.dortmund
            Case 2 : fig.BackgroundImage = My.Resources.frankfurt
            Case 3 : fig.BackgroundImage = My.Resources.hannover
            Case 4 : fig.BackgroundImage = My.Resources.schalke
            Case 5 : fig.BackgroundImage = My.Resources.wolfsburg
        End Select
        Quadros(quadro).BackgroundImage = fig.BackgroundImage
        Refresh()
        Threading.Thread.Sleep(500)
        Jogadas(quadro) = 1
        If Passo = 1 Then : Anterior = quadro
        ElseIf Matriz(quadro) <> Matriz(Anterior) Then
            Jogadas(quadro) = 0
            Jogadas(Anterior) = 0
            Quadros(quadro).BackgroundImage = My.Resources.nada
            Quadros(Anterior).BackgroundImage = My.Resources.nada
        End If
    End Sub

    Sub inicializa()
        Dim i As Integer
        For i = 0 To 11
            Quadros(i).BackgroundImage = My.Resources.nada
            Matriz(i) = 0
            Jogadas(i) = 0
        Next
        For par = 0 To 5
            For x = 0 To 1
                Do : i = Int(Rnd() * 12)
                Loop While Matriz(i) > 0
                Matriz(i) = par
            Next
        Next
        Passo = 1
    End Sub
    Private Sub Clica(sender As Object, e As EventArgs) Handles p1.Click, p9.Click, p8.Click, p7.Click, p6.Click, p5.Click, p4.Click, p3.Click, p2.Click, p12.Click, p11.Click, p10.Click
        Dim quadro As Integer
        Select Case sender.name
            Case "p1" : quadro = 0
            Case "p2" : quadro = 1
            Case "p3" : quadro = 2
            Case "p4" : quadro = 3
            Case "p5" : quadro = 4
            Case "p6" : quadro = 5
            Case "p7" : quadro = 6
            Case "p8" : quadro = 7
            Case "p9" : quadro = 8
            Case "p10" : quadro = 9
            Case "p11" : quadro = 10
            Case "p12" : quadro = 11
        End Select
        If Jogadas(quadro) <> 0 Then Return
        Call imagens(quadro)
        If Passo = 1 Then : Passo = 2
        Else : Passo = 1
        End If
        Dim ganhou = True
        For i = 0 To 12
            If Jogadas(i) = 0 Then ganhou = False
        Next
        If ganhou Then
            Beep()
            MsgBox("You won! Anime Memories!", "Fim de Jogo")
            inicializa()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        Quadros = {p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12}
        Call inicializa()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Beep()
        Dim resposta = MsgBox("Tem a certeza?", vbYesNo, "Novo Jogo")
        If resposta = vbNo Then Return
        inicializa()
    End Sub
End Class