Public Class Me_game
    Dim r As New Random()
    Dim g As Form2
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        MoveTo(Rock, 0, 2)
        MoveTo(Rock2, 0, 2)
        MoveTo(Rock3, 0, 2)
        MoveTo(Rock4, 0, 2)
        MoveTo(Rock5, 0, 2)
        MoveTo(Rock6, 0, 2)
        ''  
    End Sub


    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.A
                MoveTo(SpaceShip, -20, 0)

            Case Keys.LButton
                lazer7.Location = SpaceShip.Location
                Timer2.Enabled = True
                lazer7.Visible = True


            Case Keys.D
                MoveTo(SpaceShip, 20, 0)

            Case Keys.NumPad7
                lazer7.Location = SpaceShip.Location
                Timer2.Enabled = True
                lazer7.Visible = True

            Case Keys.NumPad8
                lazer8.Location = SpaceShip.Location
                Timer3.Enabled = True
                lazer8.Visible = True

            Case Keys.NumPad9
                lazer9.Location = SpaceShip.Location
                Timer4.Enabled = True
                lazer9.Visible = True
            Case Keys.P
                Sheld.Location = SpaceShip.Location
                Timer5.Enabled = True
                Sheld.Visible = True

            Case Keys.R
                SpaceShip.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                Me.Refresh()

            Case Keys.L
                SpaceShip.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                Me.Refresh()


            Case Else

        End Select
    End Sub
    Sub follow(p As PictureBox)
        Static headstart As Integer
        Static c As New Collection
        c.Add(SpaceShip.Location)
        headstart = headstart + 1
        If headstart > 10 Then
            p.Location = c.Item(1)
            c.Remove(1)
        End If
    End Sub

    Public Sub chase(p As PictureBox)

        Dim x, y As Integer
        If p.Location.X > SpaceShip.Location.X Then
            x = -5
        Else
            x = 5
        End If
        MoveTo(p, x, 0)
        If p.Location.Y < SpaceShip.Location.Y Then
            y = 5
        Else
            y = -5
        End If
        MoveTo(p, x, y)
    End Sub



    Function Collision(p As PictureBox, t As String, Optional ByRef other As Object = vbNull)
        Dim col As Boolean

        For Each c In Controls
            Dim obj As Control
            obj = c
            If obj.Visible AndAlso p.Bounds.IntersectsWith(obj.Bounds) And obj.Name.ToUpper.Contains(t.ToUpper) Then
                col = True
                other = obj
            End If
        Next
        Return col
    End Function
    'Return true or false if moving to the new location is clear of objects ending with t
    Function IsClear(p As PictureBox, distx As Integer, disty As Integer, t As String) As Boolean
        Dim b As Boolean

        p.Location += New Point(distx, disty)
        b = Not Collision(p, t)
        p.Location -= New Point(distx, disty)
        Return b
    End Function
    'Moves and object (won't move onto objects containing  "wall" and shows green if object ends with "win"
    Sub MoveTo(p As PictureBox, distx As Integer, disty As Integer)

        If IsClear(p, distx, disty, "WALL") Then
            p.Location += New Point(distx, disty)
        End If
        Dim other As Object = Nothing


        If p.Name = "lazer7" And Collision(p, "Rock", other) Then
            other.Visible = False
            lazer7.Visible = False
            Timer8.Enabled = True
            Return
        End If
        If p.Name = "lazer8" And Collision(p, "Rock", other) Then
            other.Visible = False
            lazer8.Visible = False

            Return
        End If
        If p.Name = "lazer9" And Collision(p, "Rock", other) Then
            other.Visible = False
            lazer9.Visible = False

            Return
        End If

        If p.Name = "lazer7" And Collision(p, "Top_wall", other) Then
            lazer7.Visible = False
            Return
        End If
        If p.Name = "SpaceShip" And Collision(p, "Rock", other) Then
            SpaceShip.Visible = False
            PLAY_AGAIN.Visible = True
            You_lost.Visible = True
            yes.Visible = True
            Timer1.Enabled = False
            Timer2.Enabled = False
            Timer3.Enabled = False
            Timer4.Enabled = False
            Timer5.Enabled = False
            Timer6.Enabled = False

            Return
        End If

    End Sub
    Public Sub stoptimers()
        Timer1.Enabled = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Timer4.Enabled = False
        Timer5.Enabled = False
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        MoveTo(lazer7, 0, -20)
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        MoveTo(lazer8, 0, -20)
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        MoveTo(lazer9, 0, -20)
    End Sub
    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs)

    End Sub

    Private Sub You_lost_Click(sender As Object, e As EventArgs) Handles You_lost.Click

    End Sub

    Private Sub yes_Click(sender As Object, e As EventArgs) Handles yes.Click
        yes.Visible = False
        PLAY_AGAIN.Visible = False
        You_lost.Visible = False
        Form2.ShowDialog()


    End Sub

    Private Sub win_Click(sender As Object, e As EventArgs) Handles win.Click

    End Sub

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        MoveTo(win, 0, 100)
        MoveTo(win, 0, 100)
        MoveTo(win, 0, 100)
        MoveTo(win, 0, 50)
        Timer6.Enabled = False
        Timer7.Enabled = True
        PLAY_AGAIN.Visible = True
        yes.Visible = True

    End Sub

    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles Timer7.Tick
        SpaceShip.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        Me.Refresh()

    End Sub

    Private Sub Timer8_Tick(sender As Object, e As EventArgs) Handles Timer8.Tick
        Rock.Visible = True
        MoveTo(Rock, 0, -100)
        lazer7.Visible = False
        Timer8.Enabled = False
    End Sub
End Class

