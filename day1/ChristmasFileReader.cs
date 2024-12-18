using System.Text.RegularExpressions;

namespace day1;

public partial class ChristmasFileReader : IDisposable
{
    [GeneratedRegex(@"^\s*(\d+)\s+(\d+)\s*$", RegexOptions.Multiline)] 
    private static partial Regex _lineRegex();
    public StreamReader _reader;
    
    public ChristmasFileReader(string path)
    {
        _reader = new StreamReader(path);
    }

    public ListPair GetListPair()
    {
        var data = _reader.ReadToEnd();
        var matches = _lineRegex().Matches(data);
        var leftList = new int[matches.Count];
        var rightList = new int[matches.Count];
        
        for (var i = 0; i < matches.Count; i++)
        {
            var match = matches[i];
            leftList[i] = int.Parse(match.Groups[1].Value);
            rightList[i] = int.Parse(match.Groups[2].Value);
        }

        return new ListPair(new SortedList(leftList), new SortedList(rightList));
    }

    public void Dispose()
    {
        _reader.Dispose();
        GC.SuppressFinalize(this);
    }
}