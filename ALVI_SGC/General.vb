Imports Shadow

Public Class General
    Public Function Encrypta(ByVal pstrInput As String) As String
        Dim objShadow As New Shadow.clsRequest
        Return objShadow.Encripta(pstrInput)
    End Function

    Public Function Decrypta(ByVal pstrInput As String) As String
        Dim objShadow As New Shadow.clsRequest
        Return objShadow.Decripta(pstrInput)
    End Function

End Class
