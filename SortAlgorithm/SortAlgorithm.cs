
public class SortAlgorithm
{
    public static void BubbleSort(int[] array)
    {
        var n = array.Length;
        for (var i = 0; i < n - 1; i++)
        {
            var swapped = false;
            for (var j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(array, j, j + 1);
                    swapped = true;
                }
            }

            if (!swapped) break;
        }
    }

    public static void SelectionSort(int[] array)
    {
        var n = array.Length;
        for (var i = 0; i < n - 1; i++)
        {
            // 最小値のインデックスを探す
            var minIndex = i;
            for (var j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex]) minIndex = j;
            }

            // 最小値を先頭に移動
            if (minIndex != i) Swap(array, i, minIndex);
        }
    }

    public static void InsertionSort(int[] array)
    {
        var n = array.Length;
        for (var i = 1; i < n; i++)
        {
            var value = array[i];
            var j = i;

            // 対象(value)より大きい要素を右にシフト
            while (j >= 1 && array[j - 1] > value)
            {
                array[j] = array[j - 1];
                j--;
            }

            // 対象(value)を正しい位置に挿入
            array[j] = value;
        }
    }

    public static void ShellSort(int[] array)
    {
        var n = array.Length;
        for (var gap = n / 2; gap > 0; gap /= 2)
        {
            for (var i = gap; i < n; i++)
            {
                // 挿入ソート
                var value = array[i];
                var j = i;

                while (j >= gap && array[j - gap] > value)
                {
                    array[j] = array[j - gap];
                    j -= gap;
                }

                array[j] = value;
            }
        }
    }

    public static void MergeSort(int[] array)
    {
        var n = array.Length;
        MergeSort(array, new int[n], 0, n - 1);
    }

    private static void MergeSort(int[] array, int[] buffer, int left, int right)
    {
        if (left >= right) return;

        var mid = (left + right) / 2;
        MergeSort(array, buffer, left, mid);
        MergeSort(array, buffer, mid + 1, right);

        //if (array[mid] <= array[mid + 1]) return;

        // マージ処理
        var li = left;
        var ri = mid + 1;
        var bi = left;
        while (li <= mid && ri <= right)
        {
            // 分割したどちらかの配列の要素が無くなるまで、小さい方の要素をバッファにコピー
            buffer[bi++] = (array[li] <= array[ri]) ? array[li++] : array[ri++];
        }

        // 残りの要素をバッファにコピー(どちらかだけが実行される)
        while (li <= mid) buffer[bi++] = array[li++];
        while (ri <= right) buffer[bi++] = array[ri++];

        // 元の配列に結果をコピー
        for (var i = left; i <= right; i++)
        {
            array[i] = buffer[i];
        }
    }

    public static void HeapSort(int[] array)
    {
        var n = array.Length;

        // 最大ヒープ(各親が子以上の値を持つヒープ)の構築
        for (var i = n / 2 - 1; i >= 0; i--)
        {
            DownHeap(array, i, n);
        }

        // ソート処理
        for (var i = n - 1; i > 0; i--)
        {
            // 最大値を末尾に移動
            Swap(array, 0, i);

            // 末尾を除いた領域について、最大ヒープの再構築
            DownHeap(array, 0, i);
        }
    }

    private static void DownHeap(int[] array, int parent, int heapSize)
    {
        var rootValue = array[parent];
        while (parent < heapSize / 2)
        {
            var left = 2 * parent + 1;
            var right = 2 * parent + 2;

            // 存在する大きい方の子を取得
            var child = (right < heapSize && array[right] > array[left]) ? right : left;

            // 根の値が子以上の場合は終了
            if (rootValue >= array[child]) break;

            // 子を親に移動し、処理を継続
            array[parent] = array[child];
            parent = child;
        }

        // 根の値を正しい位置に挿入
        array[parent] = rootValue;
    }

    public static void QuickSort(int[] array)
    {
        QuickSort(array, 0, array.Length - 1);
    }

    private static void QuickSort(int[] array, int left, int right)
    {
        if (left >= right) return;

        var pl = left;
        var pr = right;

        // ピボット選択
        var pi = (pl + pr) / 2;
        //if (array[pi] < array[pl]) Swap(array, pi, pl);
        //if (array[pr] < array[pl]) Swap(array, pr, pl);
        //if (array[pr] < array[pi]) Swap(array, pr, pi);

        // パーティション分割
        var p = array[pi];
        do
        {
            while (array[pl] < p) pl++;
            while (array[pr] > p) pr--;

            if (pl > pr) break;
            if (pl < pr) Swap(array, pl, pr);

            pl++;
            pr--;
        } while (pl <= pr);

        // 各パーティションを再帰的にソート
        QuickSort(array, left, pr);
        QuickSort(array, pl, right);
    }

    private static void Swap(int[] array, int i, int j)
    {
        var tmp = array[i];
        array[i] = array[j];
        array[j] = tmp;
    }
}
