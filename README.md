# Seçim Sonuçları Takip Uygulaması
Angular & SignalR & Asp.Net Core API & EfCore kullanılarak seçim sonuçları canlı takip senaryosu hazırlanmıştır.

#### Kullanılan Grafik Kütüphanesi

 - Kendo UI for Angular

#### Yardımcı Kütüphane

 - SqlTableDependency

#### Kullanılan Veritabanı

 - Microsoft SQL Server

#### Ek SQL Bilgisi
Asenkron olarak veritabanına bağlanıp veri alabilmemiz için sql serverın broker özelliğinin aktif edilmesi gerekiyor. Bu her tabloda farklı tanımlanmış olabilir. Tanımları görebilmek için aşağıki komut çalıştırılır.
 - select name,is_broker_enabled from sys.databases
Eğer özellik '0' ise aşaığıdaki komut çalıştırılır.
 - alter database [DboName] set Enable_Broker

*Ek olarak düzenli şekilde veritabanına veri eklemek için .Net Framework & Ado.Net kullanılarak Transaction Manager projesi oluşturulmuştur.

https://user-images.githubusercontent.com/77530565/153236356-2fae6f23-99d3-4a06-a568-a031ab1ce388.mp4
