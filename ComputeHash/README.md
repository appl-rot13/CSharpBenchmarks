## Result

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2033)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.403
  [Host]     : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
```

| Method                 | Mean      | Error    | StdDev   | Gen0    | Allocated |
|----------------------- |----------:|---------:|---------:|--------:|----------:|
| ComputeHashWithLock    | 146.55 ms | 0.559 ms | 0.496 ms |       - | 255.42 KB |
| ComputeHashWithoutLock |  28.18 ms | 0.552 ms | 0.717 ms | 31.2500 | 264.87 KB |
