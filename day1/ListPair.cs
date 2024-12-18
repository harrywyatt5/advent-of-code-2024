namespace day1;

public class ListPair
{
    private int[] _leftList;
    private int[] _rightList;

    public ListPair(SortedList left, SortedList right)
    {
        _leftList = left.GetValues();
        _rightList = right.GetValues();
    }

    public int CalculateDistance()
    {
        // Assume that lists will be the same length
        var distance = 0;
        
        for (var i = 0; i < _leftList.Length; i++)
        {
            distance += Math.Abs(_leftList[i] - _rightList[i]);
        }

        return distance;
    }
}