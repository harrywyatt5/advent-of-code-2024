namespace day1;

public class SortedList
{
    private void _merge(int left, int middle, int right)
    {
        var leftLength = middle - left + 1;
        var rightLength = right - middle;

        var leftArr = new int[leftLength];
        var rightArr = new int[rightLength];
        
        for (var i = 0; i < leftLength; i++)
        {
            leftArr[i] = _internal[left + i];
        }
        for (var i = 0; i < rightLength; i++)
        {
            rightArr[i] = _internal[middle + 1 + i];
        }

        var leftArrIndex = 0;
        var rightArrIndex = 0;
        var mergedIndex = left;

        while (leftArrIndex < leftLength && rightArrIndex < rightLength)
        {
            if (leftArr[leftArrIndex] <= rightArr[rightArrIndex])
            {
                _internal[mergedIndex] = leftArr[leftArrIndex];
                leftArrIndex++;
            }
            else
            {
                _internal[mergedIndex] = rightArr[rightArrIndex];
                rightArrIndex++;
            }

            mergedIndex++;
        }
        
        while (leftArrIndex < leftLength)
        {
            _internal[mergedIndex] = leftArr[leftArrIndex];
            leftArrIndex++;
            mergedIndex++;
        }
        
        while (rightArrIndex < rightLength)
        {
            _internal[mergedIndex] = rightArr[rightArrIndex];
            rightArrIndex++;
            mergedIndex++;
        }
    }

    private void _mergeSort(int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            _mergeSort(left, middle);
            _mergeSort(middle + 1, right);
            _merge(left, middle, right);
        }
    }

    private int[] _internal;

    public SortedList(int[] values)
    {
        _internal = values;
        _mergeSort(0, _internal.Length - 1);
    }
    
    public int[] GetValues()
    {
        return _internal;
    }
}