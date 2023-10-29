# ef-core-tracking-benchmark
Benchmark of ef core performance. .Net core + PostgreSQL

# Problem
Ef core has a high preformance optimizations for connecting with databases.
But a lots of developers don't think about it at the start of the project.

When I started one of the app in Debug (when I coming to company), i saw a lot of messagess about tracking of entities.
And then a want to check how does this affect to performance

## You can use this package as base for benchmark of EFCore

## Results

### Set of 100 records:

| Method                  | Mean     | Error   | StdDev   |
|------------------------ |---------:|--------:|---------:|
| WithTracking            | 213.7 us | 7.64 us | 21.42 us |
| WithoutTracking         | 243.7 us | 4.84 us | 14.05 us |
| WithTrackingAndOrder    | 365.2 us | 7.25 us | 18.73 us |
| WithoutTrackingAndOrder | 384.9 us | 9.53 us | 27.81 us |
Summary: look, just 100 records and we have so big difference

### Set of 1000 records

| Method                  | Mean       | Error    | StdDev    | Median     |
|------------------------ |-----------:|---------:|----------:|-----------:|
| WithTracking            |   548.4 us | 39.67 us | 114.44 us |   505.1 us |
| WithoutTracking         |   662.6 us | 12.90 us |  35.52 us |   658.2 us |
| WithTrackingAndOrder    | 1,743.5 us | 33.84 us |  40.28 us | 1,749.6 us |
| WithoutTrackingAndOrder | 1,822.1 us | 36.13 us |  33.80 us | 1,822.6 us |
Summary: for this sample there is also an influence, but not proportional

### Set of 10.000 records

| Method                  | Mean      | Error     | StdDev    |
|------------------------ |----------:|----------:|----------:|
| WithTracking            |  3.684 ms | 0.0726 ms | 0.1345 ms |
| WithoutTracking         |  7.417 ms | 0.1418 ms | 0.1392 ms |
| WithTrackingAndOrder    | 17.744 ms | 0.1165 ms | 0.1033 ms |
| WithoutTrackingAndOrder | 20.969 ms | 0.2429 ms | 0.2272 ms |
Summary: in simple case (without order) we see that `AsNoTracking` option performance is twice as fast. And at the same time `AsNoTracking` and 'OrderBy' give different result. I think that it's relates with inclided performance optimizations of EF Core.

### Set of 100.000 records

| Method                  | Mean      | Error    | StdDev   |
|------------------------ |----------:|---------:|---------:|
| WithTracking            |  36.62 ms | 0.612 ms | 0.680 ms |
| WithoutTracking         |  79.15 ms | 1.546 ms | 1.518 ms |
| WithTrackingAndOrder    | 178.48 ms | 3.519 ms | 4.575 ms |
| WithoutTrackingAndOrder | 211.31 ms | 4.212 ms | 7.037 ms |
Summary: result same as at previous dataset, but last method `WithoutTrackingAndOrder` takes a little longer to complete

### Set of 1.000.000 records

| Method                  | Mean       | Error    | StdDev   |
|------------------------ |-----------:|---------:|---------:|
| WithTracking            |   319.6 ms |  5.27 ms |  4.67 ms |
| WithoutTracking         |   799.2 ms | 11.70 ms | 10.37 ms |
| WithTrackingAndOrder    | 1,192.1 ms | 22.99 ms | 23.61 ms |
| WithoutTrackingAndOrder | 1,607.8 ms | 18.42 ms | 15.38 ms |
Summary: same as previously

# In result
Выше мы рассмотрели и сравнили результаты с одним из параметом `AsNoTracking`.
Как мы видим, этот параметр весьма существенно влияет на эффективность запросов и обработке данных и на наборе более 10.000 объектов работает вдвое быстрее.
Можно установить это значение по-умолчанию, тогда при изменении объектов необходимо получать объекты с методом `AsTracking`.
Учтите это в своих решениях.

# Contacts
Social: @mushegovdima
Email: mushegovdima@yandex.ru