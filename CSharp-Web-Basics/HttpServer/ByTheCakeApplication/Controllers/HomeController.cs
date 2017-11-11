using System;
using System.Collections.Generic;

public class HomeController : Controller
{
    public IHttpResponse Index() => this.FileViewResponse(@"home\index");

    public IHttpResponse SessionTest(IHttpRequest req)
    {
        var session = req.Session;

        const string sessionDateKey = "saved_date";

        if (session.Get(sessionDateKey) == null)
        {
            session.Add(sessionDateKey, DateTime.UtcNow);
        }

        return new ViewResponse(
            HttpStatusCode.Ok,
            new SessionTestView(session.Get<DateTime>(sessionDateKey)));
    }

    public IHttpResponse About() => this.FileViewResponse(@"home\about");

    public IHttpResponse Calculate(string firstNumber, string calculateOperator, string secondNumber)
    {
        decimal firstNum = decimal.Parse(firstNumber);
        decimal secondNum = decimal.Parse(secondNumber);
        decimal result = 0;

        if (calculateOperator == "+")
        {
            result = firstNum + secondNum;
        }
        else if (calculateOperator == "-")
        {
            result = firstNum - secondNum;
        }
        else if (calculateOperator == "*")
        {
            result = firstNum * secondNum;
        }
        else if (calculateOperator == "/")
        {
            result = firstNum / secondNum;
        }
        else
        {
        }

        var strResult = result.ToString();

        return this.FileViewResponse(@"home\calculator", new Dictionary<string, string>
        {
            ["result"] = strResult
        });
    }

    public IHttpResponse Calculate() => this.FileViewResponse(@"home\calculator");

    public IHttpResponse Login() => this.FileViewResponse(@"home\login");

    public IHttpResponse Login(string username, string passwod)
    {
        return this.FileViewResponse(@"home\login", new Dictionary<string, string>
        {
            ["username"] = username,
            ["password"] = passwod
        });
    }
}