Imports System.IO

Public Class Read
    Public Shared Function ReadContent(filePath As String) As String
        Try
            ' 读取整个文件内容到一个字符串中
            Dim fileContent As String = File.ReadAllText(filePath)

            ' 输出文件内容
            Console.WriteLine(fileContent)

            Return fileContent
        Catch ex As Exception
            ' 如果发生异常，输出异常信息
            Console.WriteLine("An error occurred: " & ex.Message)

            Return ex.Message
        End Try
    End Function

    Public Shared Async Function ReadContentAsync(filePath As String) As Task(Of String)
        Try
            ' 使用异步方法读取整个文件内容到一个字符串中
            Dim fileContent As String = Await File.ReadAllTextAsync(filePath)

            ' 输出文件内容
            Console.WriteLine(fileContent)

            Return fileContent
        Catch ex As Exception
            ' 如果发生异常，输出异常信息
            Console.WriteLine("An error occurred: " & ex.Message)

            Return ex.Message
        End Try
    End Function
End Class
