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
