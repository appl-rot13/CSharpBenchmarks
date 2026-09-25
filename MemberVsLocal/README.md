## Result

- メンバ変数よりローカル変数の方がアクセスが速い

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2033)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.403
  [Host]     : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
```

| Method        | Mean     | Error    | StdDev   | Allocated |
|-------------- |---------:|---------:|---------:|----------:|
| CompareMember | 29.02 ns | 0.118 ns | 0.110 ns |         - |
| CompareLocal  | 11.65 ns | 0.311 ns | 0.917 ns |         - |

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26200.9550)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.401
  [Host]     : .NET 10.0.12 (10.0.1226.42308), X64 RyuJIT AVX2
  DefaultJob : .NET 10.0.12 (10.0.1226.42308), X64 RyuJIT AVX2
```

| Method        | Mean     | Error    | StdDev   | Allocated |
|-------------- |---------:|---------:|---------:|----------:|
| CompareMember | 21.60 ns | 0.051 ns | 0.042 ns |         - |
| CompareLocal  | 10.31 ns | 0.097 ns | 0.091 ns |         - |
