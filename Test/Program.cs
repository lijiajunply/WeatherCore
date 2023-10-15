// See https://aka.ms/new-console-template for more information

Console.WriteLine(DateProgress("6:42","17:42"));

return;

double DateProgress(string start, string end)
{
    var now = DateTime.Now;
    var startDate = DateTime.Parse(start);
    var endDate = DateTime.Parse(end);
    var total = endDate - startDate;
    var nowProgress = now - startDate;
    return (nowProgress.TotalMinutes / total.TotalMinutes)*100;
}