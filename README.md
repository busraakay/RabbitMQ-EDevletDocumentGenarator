# 🏢 EDevlet Document Generator

Bu proje, RabbitMQ kullanarak belge oluşturma işlemlerini yöneten basit bir mesaj tabanlı asenkron mikroservis örneğidir. 

## 📋 Genel Bakış

- **Görev:** Kullanıcıdan gelen belge oluşturma isteklerini (`create_document_queue`) dinler, belgeleri oluşturur ve sonuçları (`document_created_queue`) ilgili kuyruğa yazar.
- **Teknolojiler:**  
  - .NET (Console app ve Windows Form örnekleri)
  - RabbitMQ (mesaj kuyruğu)
  - Newtonsoft.Json (JSON serileştirme/deserileştirme)

## 🗂 Proje Yapısı

- `EDevlet.Document.Common`: Ortak veri modellerini içerir (`CreateDocumentModel`, `DocumentType` enum).
- `EDevlet.Document.Creator`: Konsol uygulaması, RabbitMQ'dan gelen mesajları dinleyip belge oluşturur.
- (Ek olarak, form tabanlı istemci projen olabilir — RabbitMQ'ya istek gönderir ve sonucu dinler.)

## ⚙️ Nasıl Çalışır?

1. **İstek Gönderme:**  
   Belge oluşturmak isteyen uygulama, `create_document_queue` kuyruğuna `CreateDocumentModel` tipinde JSON mesaj gönderir.

2. **İşleyici (Consumer):**  
   `EDevlet.Document.Creator` adlı konsol uygulaması bu kuyruğu dinler.
   
3. **Belge Oluşturma:**  
   Mesaj alınca belge oluşturma süreci (simülasyon olarak 5 saniye bekleme) yapılır.  
   
4. **Sonuç Gönderme:**  
   Belge URL'si `CreateDocumentModel`'e atanır ve `document_created_queue` kuyruğuna JSON formatında gönderilir.

5. **Sonuç Alımı:**  
   İstemci uygulama sonuç kuyruğunu dinleyerek belge URL'sini alır.

---

## 📡 Kullanılan Kuyruklar ve Exchange

| Exchange              | Tip     | Queue                  | Routing Key           | Açıklama                        |
|-----------------------|---------|------------------------|-----------------------|--------------------------------|
| `document_create_exchange` | direct  | `create_document_queue`  | `create_document_queue` | Belge oluşturma istekleri       |
| `document_create_exchange` | direct  | `document_created_queue` | `document_created_queue` | Belge oluşturma sonucu mesajları|

---

## 🛠 Kurulum ve Çalıştırma

### 🐇 RabbitMQ Kurulumu

- [RabbitMQ resmi sitesi](https://www.rabbitmq.com/download.html) üzerinden indirip kurabilirsiniz.
- RabbitMQ yönetim paneli için: `http://localhost:15672/`  
  Default kullanıcı: `guest`  
  Şifre: `guest`

### ▶️ Projeyi Çalıştırmak

1. RabbitMQ çalışıyor ve erişilebilir olmalı.
2. `EDevlet.Document.Creator` projesini derleyip çalıştırın. Konsol açıldığında kuyruğu dinlemeye başlayacaktır.
3. İstek gönderen istemci uygulama, `create_document_queue` kuyruğuna mesaj göndermelidir.
4. İşleyici (consumer) mesajı alıp işledikten sonra sonucu `document_created_queue` kuyruğuna gönderecektir.

---

## 📐 Örnek Mesaj Modeli (`CreateDocumentModel`)

```csharp
public class CreateDocumentModel
{
    public int UserId { get; set; }
    public string Url { get; set; } // Oluşturulan belge URL'si
    public DocumentType DocumentType { get; set; }
}

public enum DocumentType
{
    Document,
    Html,
    Png
}
