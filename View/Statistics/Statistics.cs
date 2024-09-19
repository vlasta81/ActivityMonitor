using System.Text;
using ActivityMonitor.Entities;
using ActivityMonitor.Libraries.ChangeLogTypes;

namespace ActivityMonitor.View.Statistics
{
    public static class Statistics
    {
        public static List<List<ChangeLog>> ProcessChangeLogs(List<ChangeLog> changeLogs)
        {
            if (changeLogs == null || !changeLogs.Any())
                return new List<List<ChangeLog>>();

            Guid activityId = changeLogs.First().ActivityId;

            return changeLogs
                .OrderBy(cl => cl.Created)
                .Aggregate(new List<List<ChangeLog>>(), (acc, cl) =>
                {
                    if (cl.Type == ChangeLogTypes.Begin || !acc.Any())
                    {
                        acc.Add(new List<ChangeLog> { cl });
                    }
                    else
                    {
                        acc.Last().Add(cl);
                        if (cl.Type == ChangeLogTypes.End)
                        {
                            if (acc.Last().First().Type != ChangeLogTypes.Begin)
                            {
                                acc.RemoveAt(acc.Count - 1);
                            }
                            else if (acc.Last().Count > 1)
                            {
                                acc.Add(new List<ChangeLog>());
                            }
                        }
                    }
                    return acc;
                })
                .Where(block => block.Any() &&
                       block.First().Type == ChangeLogTypes.Begin &&
                       block.Last().Type == ChangeLogTypes.End)
                .ToList();
        }
        public static string GenerateHtml(List<List<ChangeLog>> changeLogs, string fileName)
        {
            var totalDuration = TimeSpan.Zero;
            var htmlBuilder = new StringBuilder();

            htmlBuilder.AppendLine($@"<!DOCTYPE html>
<html lang=""{Properties.Resources.HtmlTemplateLang}"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>{Properties.Resources.HtmlTemplateStatistics}Statistics</title>
    <style>
        .timeline {{
            width: 100%;
            height: 30px;
            background-color: #4CAF50;
            position: relative;
            margin-top: 20px;
        }}
        .event {{
            width: 5px;
            height: 30px;
            background-color: red;
            position: absolute;
            top: 0;
        }}
        .startstop {{
            width: 2px;
            height: 50px;
            background-color: blue;
            position: absolute;
            top: 0;
        }}
        .clearfix::after {{
            content: """";
            clear: both;
            display: table;
        }}
    </style>
</head>
<body>
    <h1>{Properties.Resources.HtmlTemplateStatistics}</h1>
    <p>{Properties.Resources.HtmlTemplateFile}: <b>" + fileName + @"</b></p><hr>");

            foreach (var block in changeLogs)
            {
                if (block.Count < 2) continue;

                var start = block.First(cl => cl.Type == ChangeLogTypes.Begin).Created;
                var end = block.Last(cl => cl.Type == ChangeLogTypes.End).Created;
                var duration = end - start;
                totalDuration += duration;

                htmlBuilder.AppendLine($@"
    <div style=""padding-bottom: 10px;"">
        <p><span style=""float: left;"">{Properties.Resources.HtmlTemplateBegin}: <b>{start.ToString()}</b></span><span style=""float: right;""><b>{end.ToString()}</b> :{Properties.Resources.HtmlTemplateEnd}</span></p>
        <div class=""clearfix""></div>
        <div class=""timeline"">");
                foreach (var changeLog in block)
                {
                    if (changeLog.Type != ChangeLogTypes.Begin && changeLog.Type != ChangeLogTypes.End)
                    {
                        double td = (end - start).TotalMilliseconds;
                        double elapsedDuration = (changeLog.Created - start).TotalMilliseconds;
                        double position = (elapsedDuration / td) * 100;
                        htmlBuilder.AppendLine($@"            <div class=""event"" style=""left: {position:F0}%;"" title=""{changeLog.Type} - {changeLog.Created.ToString()}""></div>");
                    }
                }
                htmlBuilder.AppendLine($@"            
        </div><p>{Properties.Resources.HtmlTemplateDuration}: <b>{duration.ToString()}</b></p>        
        <hr>
    </div>");
            }
            htmlBuilder.AppendLine($@"    <h2>{Properties.Resources.HtmlTemplateTotalDuration}: {totalDuration.ToString()}</h2>
</body>
</html>");

            return htmlBuilder.ToString();
        }

    }
}
