## Result

- IEnumerable<byte>のSequenceEqual()は内部で型判定して高速化しているはずだが、意外と遅い
- byte[]をAsSpan()でSpan<byte>に変換してからSequenceEqual()を呼び出すのが、安定して速い
- 配列のサイズが小さい、配列が異なる可能性が高い等の条件次第では、forループも候補になる

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2033)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.403
  [Host]     : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
```

| Method                    | N    | ArrayEquals | Mean        | Error     | StdDev    | Median      | Allocated |
|-------------------------- |----- |------------ |------------:|----------:|----------:|------------:|----------:|
| CompareWithForLoop        | 32   | False       |   0.8877 ns | 0.0113 ns | 0.0101 ns |   0.8855 ns |         - |
| CompareWithSequenceEqual  | 32   | False       |  15.8233 ns | 0.2436 ns | 0.2278 ns |  15.8469 ns |         - |
| CompareCastToReadOnlySpan | 32   | False       |   2.1951 ns | 0.0112 ns | 0.0100 ns |   2.1952 ns |         - |
| CompareCastToSpan         | 32   | False       |   2.2159 ns | 0.0172 ns | 0.0152 ns |   2.2126 ns |         - |
| CompareAsSpan             | 32   | False       |   1.9357 ns | 0.0100 ns | 0.0093 ns |   1.9316 ns |         - |
| CompareWithForLoop        | 32   | True        |  15.6375 ns | 0.5597 ns | 1.6504 ns |  16.0947 ns |         - |
| CompareWithSequenceEqual  | 32   | True        |  15.1381 ns | 0.1256 ns | 0.1174 ns |  15.1250 ns |         - |
| CompareCastToReadOnlySpan | 32   | True        |   2.9476 ns | 0.0399 ns | 0.0333 ns |   2.9516 ns |         - |
| CompareCastToSpan         | 32   | True        |   2.2322 ns | 0.0186 ns | 0.0155 ns |   2.2331 ns |         - |
| CompareAsSpan             | 32   | True        |   1.9861 ns | 0.0293 ns | 0.0274 ns |   1.9799 ns |         - |
| CompareWithForLoop        | 1024 | False       |   0.8295 ns | 0.0051 ns | 0.0045 ns |   0.8296 ns |         - |
| CompareWithSequenceEqual  | 1024 | False       |  14.8086 ns | 0.0376 ns | 0.0333 ns |  14.8142 ns |         - |
| CompareCastToReadOnlySpan | 1024 | False       |   2.1083 ns | 0.0312 ns | 0.0277 ns |   2.1121 ns |         - |
| CompareCastToSpan         | 1024 | False       |   2.0267 ns | 0.0206 ns | 0.0193 ns |   2.0216 ns |         - |
| CompareAsSpan             | 1024 | False       |   1.7217 ns | 0.0040 ns | 0.0031 ns |   1.7227 ns |         - |
| CompareWithForLoop        | 1024 | True        | 352.9104 ns | 2.2262 ns | 2.0823 ns | 351.8455 ns |         - |
| CompareWithSequenceEqual  | 1024 | True        |  32.5031 ns | 0.6807 ns | 1.5226 ns |  33.5008 ns |         - |
| CompareCastToReadOnlySpan | 1024 | True        |  21.0777 ns | 0.0462 ns | 0.0432 ns |  21.0781 ns |         - |
| CompareCastToSpan         | 1024 | True        |  15.6337 ns | 0.3397 ns | 0.5581 ns |  15.8454 ns |         - |
| CompareAsSpan             | 1024 | True        |  15.3748 ns | 0.3214 ns | 0.2849 ns |  15.4653 ns |         - |
