## Result

- StringBuilderが安定して速い
- 可能であれば最大文字列長を指定する

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2605)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.101
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
```

| Method                   | Mean     | Error    | StdDev   | Gen0   | Allocated |
|------------------------- |---------:|---------:|---------:|-------:|----------:|
| OperatorAggregate        | 76.27 ns | 0.404 ns | 0.358 ns | 0.0468 |     392 B |
| Operator                 | 50.56 ns | 0.441 ns | 0.412 ns | 0.0325 |     272 B |
| Concat                   | 51.93 ns | 0.211 ns | 0.197 ns | 0.0210 |     176 B |
| Builder                  | 27.78 ns | 0.089 ns | 0.083 ns | 0.0172 |     144 B |
| BuilderSpecifiedCapacity | 26.30 ns | 0.235 ns | 0.220 ns | 0.0153 |     128 B |
