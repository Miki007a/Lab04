```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5608/22H2/2022Update)
Intel Core i5-4460 CPU 3.20GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX2


```
| Method                        | Mean    | Error   | StdDev  |
|------------------------------ |--------:|--------:|--------:|
| FetchWithEntityFrameworkAsync | 59.14 s | 0.198 s | 0.175 s |
| FetchWithDapperAsync          | 40.95 s | 0.480 s | 0.426 s |
| FetchWithOracleClientAsync    | 62.83 s | 1.211 s | 1.133 s |
