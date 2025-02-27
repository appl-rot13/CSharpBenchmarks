## Result

- StringCreateが使えるなら使う
- StringBuilderは安定して速い
- 可能であれば最大文字列長を指定する

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2
```

| Method                           | Mean     | Error    | StdDev   | Gen0   | Allocated |
|--------------------------------- |---------:|---------:|---------:|-------:|----------:|
| OperatorAggregate                | 77.91 ns | 1.121 ns | 1.049 ns | 0.0468 |     392 B |
| Operator                         | 55.74 ns | 1.135 ns | 1.214 ns | 0.0325 |     272 B |
| Concat                           | 55.47 ns | 0.903 ns | 0.845 ns | 0.0210 |     176 B |
| Builder                          | 28.62 ns | 0.611 ns | 0.654 ns | 0.0172 |     144 B |
| BuilderSpecifiedCapacity         | 28.00 ns | 0.516 ns | 0.483 ns | 0.0153 |     128 B |
| StringCreate                     | 10.08 ns | 0.058 ns | 0.052 ns | 0.0048 |      40 B |
| DefaultInterpolatedStringHandler | 39.90 ns | 0.210 ns | 0.186 ns | 0.0048 |      40 B |
