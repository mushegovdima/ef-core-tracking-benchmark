# ef-core-tracking-benchmark
Benchmark of ef core performance. .Net core + PostgreSQL

# Problem
EF core has a high preformance optimizations for connecting with database.
But a lots of developers don't think about it at the start of the project.

When I started one of the app in Debug (when I coming to company), i saw a lot of messagess about tracking of entities.
And then a want to check how does this affect to performance

## You can use this package as base for benchmark of EFCore

## Results

### Set of 100 records:

| Method                  | Mean     | Error    | StdDev   |
|------------------------ |---------:|---------:|---------:|
| WithTracking            | 521.6 us | 10.28 us | 11.43 us |
| WithoutTracking         | 395.2 us |  6.43 us |  5.70 us |
| WithTrackingAndOrder    | 683.7 us | 12.76 us | 13.11 us |
| WithoutTrackingAndOrder | 548.2 us | 10.76 us | 20.72 us |
Summary: look, just 100 records and we have so big difference

### Set of 1000 records

| Method                  | Mean       | Error    | StdDev   |
|------------------------ |-----------:|---------:|---------:|
| WithTracking            | 2,193.3 us | 38.75 us | 36.25 us |
| WithoutTracking         |   833.0 us | 12.46 us | 10.41 us |
| WithTrackingAndOrder    | 3,707.3 us | 55.82 us | 46.61 us |
| WithoutTrackingAndOrder | 2,073.3 us | 26.42 us | 24.71 us |
Summary: for this sample `WithoutTracking` is faster more then twice 

### Set of 10.000 records

| Method                  | Mean      | Error     | StdDev    | Median    |
|------------------------ |----------:|----------:|----------:|----------:|
| WithTracking            | 30.820 ms | 0.5955 ms | 1.5895 ms | 30.323 ms |
| WithoutTracking         |  7.939 ms | 0.1398 ms | 0.1308 ms |  7.942 ms |
| WithTrackingAndOrder    | 42.891 ms | 0.8493 ms | 0.7944 ms | 42.776 ms |
| WithoutTrackingAndOrder | 22.248 ms | 0.4247 ms | 0.3765 ms | 22.346 ms |
Summary: in simple case (without order) we see that `AsNoTracking` option performance is x4 faster. And at the same time `AsNoTracking` and `OrderBy` give different result. I think that it's relates with included performance optimizations of EF Core.

### Set of 100.000 records


| Method                  | Mean      | Error    | StdDev   |
|------------------------ |----------:|---------:|---------:|
| WithTracking            | 312.45 ms | 5.936 ms | 6.351 ms |
| WithoutTracking         |  81.35 ms | 1.508 ms | 1.411 ms |
| WithTrackingAndOrder    | 453.65 ms | 8.072 ms | 7.551 ms |
| WithoutTrackingAndOrder | 208.51 ms | 4.040 ms | 4.149 ms |
Summary: result same as at previous dataset, but last method `WithoutTrackingAndOrder` takes a little longer to complete

### Set of 1.000.000 records

| Method                  | Mean       | Error    | StdDev    |
|------------------------ |-----------:|---------:|----------:|
| WithTracking            | 3,511.5 ms | 70.10 ms | 122.77 ms |
| WithoutTracking         |   851.1 ms | 13.34 ms |  12.48 ms |
| WithTrackingAndOrder    | 4,083.4 ms | 49.27 ms |  43.68 ms |
| WithoutTrackingAndOrder | 1,634.6 ms | 31.82 ms |  40.25 ms |
Summary: same as previously

# In result
We've discussed and compared the results with one of the parameters, `AsNoTracking`. As we can see, this parameter significantly affects query efficiency and data processing, and it runs twice as fast on a dataset of over 1,000 objects.
You can set this value as the default, and when you need to track changes to objects, you can obtain objects with the `AsTracking` method.

Keep this in mind when making your decisions.

# Contacts
Social: @mushegovdima
Email: mushegovdima@yandex.ru