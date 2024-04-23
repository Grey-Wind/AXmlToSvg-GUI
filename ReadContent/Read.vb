Imports System.IO

Public Class Read
    Public Shared Function ReadContent(filePath As String) As String
        Try
            ' ��ȡ�����ļ����ݵ�һ���ַ�����
            Dim fileContent As String = File.ReadAllText(filePath)

            ' ����ļ�����
            Console.WriteLine(fileContent)

            Return fileContent
        Catch ex As Exception
            ' ��������쳣������쳣��Ϣ
            Console.WriteLine("An error occurred: " & ex.Message)

            Return ex.Message
        End Try
    End Function

    Public Shared Async Function ReadContentAsync(filePath As String) As Task(Of String)
        Try
            ' ʹ���첽������ȡ�����ļ����ݵ�һ���ַ�����
            Dim fileContent As String = Await File.ReadAllTextAsync(filePath)

            ' ����ļ�����
            Console.WriteLine(fileContent)

            Return fileContent
        Catch ex As Exception
            ' ��������쳣������쳣��Ϣ
            Console.WriteLine("An error occurred: " & ex.Message)

            Return ex.Message
        End Try
    End Function
End Class
