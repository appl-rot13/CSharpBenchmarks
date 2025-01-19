## Result

- `Process.GetProcessesByName().Length` で判定するのが安定して速い

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2894)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.12 (8.0.1224.60305), X64 RyuJIT AVX2
```

### プロセスが存在しない場合

| Method                   | Mean     | Error     | StdDev    | Gen0    | Gen1    | Allocated |
|------------------------- |---------:|----------:|----------:|--------:|--------:|----------:|
| GetProcessesAny          | 1.691 ms | 0.0337 ms | 0.0544 ms | 54.6875 | 21.4844 | 455.54 KB |
| GetProcessesForEach      | 1.537 ms | 0.0284 ms | 0.0279 ms | 54.6875 | 35.1563 | 451.86 KB |
| GetProcessesByNameAny    | 1.355 ms | 0.0259 ms | 0.0327 ms |       - |       - |   2.14 KB |
| GetProcessesByNameLength | 1.352 ms | 0.0269 ms | 0.0350 ms |       - |       - |   2.14 KB |

### プロセスが存在する場合

| Method                   | Mean     | Error     | StdDev    | Gen0    | Gen1    | Allocated |
|------------------------- |---------:|----------:|----------:|--------:|--------:|----------:|
| GetProcessesAny          | 1.675 ms | 0.0229 ms | 0.0191 ms | 54.6875 | 33.2031 | 451.49 KB |
| GetProcessesForEach      | 1.514 ms | 0.0300 ms | 0.0368 ms | 54.6875 | 29.2969 | 448.92 KB |
| GetProcessesByNameAny    | 1.345 ms | 0.0266 ms | 0.0306 ms |       - |       - |   4.46 KB |
| GetProcessesByNameLength | 1.315 ms | 0.0262 ms | 0.0219 ms |       - |       - |   4.46 KB |
