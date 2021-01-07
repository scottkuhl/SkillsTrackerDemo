using Ardalis.GuardClauses;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using SkillsTracker.Models;
using System;
using System.IO;

namespace SkillsTracker.Controllers
{
    public class SkillsController : Controller
    {
        [Route("/skills")]
        public IActionResult DisplaySkillsAvailable()
        {
            string html =
                "<h1>Skills Tracker</h1>" +
                    "<h2>Coding skills to learn:</h2>" +
                    "<ol>" +
                        "<li>C#</li>" +
                        "<li>JavaScript</li>" +
                        "<li>Pyhton</li>" +
                    "</ol>";

            return Content(html, "text/html");
        }

        [Route("/skills/form")]
        public IActionResult DisplaySkillsForm()
        {
            string html =
                "<form method='post'>" +
                    "Date: <br />" +
                    "<input type='date' name='date' />" +
                    "<br /><br />C#<br />" +
                    "<select name='csharpProgress'>" +
                        "<option value='learning basics'>Learning Basics</option>" +
                        "<option value='making apps'>Making Apps</option>" +
                        "<option value='master coder'>Master Coder</option>" +
                    "</select>" +
                    "<br /><br />JavaScript<br />" +
                    "<select name='jsProgress'>" +
                        "<option value='learning basics'>Learning Basics</option>" +
                        "<option value='making apps'>Making Apps</option>" +
                        "<option value='master coder'>Master Coder</option>" +
                    "</select>" +
                    "<br /><br />Python<br />" +
                    "<select name='pythonProgress'>" +
                        "<option value='learning basics'>Learning Basics</option>" +
                        "<option value='making apps'>Making Apps</option>" +
                        "<option value='master coder'>Master Coder</option>" +
                    "</select>" +
                    "<br /><br />" +
                    "<input type='submit' value='Submit' />" +
                "</form>";

            return Content(html, "text/html");
        }

        [HttpPost, Route("/skills/form")]
        public IActionResult PostSkillsForm(DateTime date, string csharpProgress, string jsProgress, string pythonProgress)
        {
            Guard.Against.NullOrEmpty(csharpProgress, nameof(csharpProgress));

            if (csharpProgress != "learning basics" && csharpProgress != "making apps" && csharpProgress != "master coder")
            {
                throw new ArgumentOutOfRangeException("csharpProgress", "Invalid Input");
            }

            try
            {
                Console.WriteLine(csharpProgress);
            }
            catch (IOException ex)
            {
                throw new MyFileException("File Write Failed.Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("File Write Failed.Please try again.", ex);
            }

            string html =
                "<h1>" + date.Humanize() + "</h1>" +
                "<ol>" +
                    "<li>C#: " + csharpProgress + "</li>" +
                    "<li>JavaScript: " + jsProgress + "</li>" +
                    "<li>Python: " + pythonProgress + "</li>" +
                "</ol>";

            return Content(html, "text/html");
        }
    }
}
