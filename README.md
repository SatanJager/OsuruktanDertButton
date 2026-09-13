# Osuruktan Dert Button 💨

2000'lerin o meşhur "işe yaramaz ama sevimli masaüstü programlarına bir saygı duruşu. Derdinizi yazun, "Çözüm" butonuna basın - derdinizi anında (ve haklı olarak) önemsiz ilan etsin.

> 📋 Bu proje Jira üzerinden epic/story bazlı olarak takip edilmektedir. Geliştirme süreci sprint'ler halinde ilerlemektedir.

---

## Turkce

🇹🇷 Türkçe | [🇬🇧 English](#english) | [🇩🇪 Deutsch](#deutsch)

## Ne işe yarar?

- Bir metin kutusuna derdinizi/sorununuzu yazarsınız.
- **Çözüm** butonuna basarsınız.
- Kutu temizlenir, ekranda şu mesaj çıkar: *"Derdiniz çok osuruktan bulundu. Çözüm gerekmiyor."*
- Dert kaybolmaz - sessizce kaydedilir. **Önceki Dertlerim** penceresinden geçmişe göz atabilirisiniz.

## Özellikler

- 🌍 **3 dil desteği**: Türkçe, İngilizce, Almanca
- 📝 **Geçmiş kaydı**: Her dert, tarih/saat damgasıyla birlikte saklanır
- 🔒 **Kullanıcı özel depolama**: Dertler `%APPDATA%\OsuruktanDertButton\complaints.txt` içinde tutulur — program dosyası paylaşılsa bile dertler o kullanıcıya özel kalır, başkasına gitmez
- 🗑️ **Geçmişi temizleme**: Tek tıkla tüm kayıtları silme

## Teknoloji

- **C# / .NET 8**
- **Windows Forms (Winforms)**

## Nasıl çalışır?

1. Bu repoyu klonlayın veya indirin.
2. Visiual Studio ile `OsuruktanDertButton.csproj` dosyasını açın (.NET 8 SDK gereklidir).
3. `F5` ile çalıştırın.

## Proje Yapısı

| Dosya | Açıklama |
| --- | --- |
| `Program.cs` | Uygulamanın giriş noktası |
| `MainForm.cs` | Ana pencere — dert giriş ekranı, dil seçici |
| `HistoryForm.cs` | "Önceki Dertlerim" penceresi |
| `Localization.cs` | TR/EN/DE metin çevirileri |
| `ComplaintStore.cs` | Dertlerin diske yazılması/okunması |

## Yol Haritası

Proje aşağıdaki epic'ler halinde geliştiriliyor:

- [x] Temel UI ve dil desteği
- [x] Kayıt mekanizması (dert kaydetme, geçmiş görüntüleme, temizleme)
- [ ] Cilalama (yuvarlak animasyonlu "Çözüm" butonu, kullanılabilirlik iyileştirmeleri
- [ ] Ekstra özellikler (versiyonlama, ikon, sistem tepsisine küçütme, ses efektleri)

## Katkıda Bulunma

Bu bir öğrenme/eğlence projesi olarak geliştiriliyor. Öneri ve geri bildirimler için issue açabilirsiniz.

## Lisans

Henüz belirlenmedi.

---

## English

[🇹🇷 Türkçe](#turkce) | 🇬🇧 English | [🇩🇪 Deutsch](#deutsch)

A tribute to the beloved, gloriously useless dektop programs of the 2000s. Type your problem, press **Solve** - the app will instantly (and correctly) declare it trivial.

> 📋 This project is tracked via Jira on an epic/story basis. The development process proceeds in sprints.

## How it works

- Type your problemin the text box and press **Solve**.
- The box clears and a message appears: *"Your problem has been classified as fart-grade trivial. No solution required."*
- Nothing is lost - every problem is quietly saved, and you can browse your history anytime from **My Previous Problems**.

## Features

- 🌍 **3 languages**: Turkish, English, German
- 📝 **History log**: History with timestams for every entry
- 🔒 **Per-user storage**: Compaints are saved under `%APPDATA%\OsuruktanDertButton\complaints.txt`, so sharing the app never shares your data
- 🗑️ **Clearing the past**: One-click history clearing

## Tech stack

- **C# / .NET 8**
- **Windows Forms (Winforms)**

## Running it

- Clone the repo.
- Open  `OsuruktanDertButton.csproj` in Visual Studio (.NET 8 SDK required).
- Press `F5`.

## License

Not yet determined.

---

## Deutsch

[🇹🇷 Türkçe](#turkce) | [🇬🇧 English](#english) | 🇩🇪 Deutsch

Eine Hommage an die herrlich nutzlosen, aber liebenswerten Desktop-Programme der 2000er-Jahre. Schreiben Sie Ihr Problem, klicken Sie auf **Lösung** — die App erklärt es umgehend (und zu Recht) für unbedeutend.

> 📋 Dieses Projekt wird über Jira auf Basis von Epics und Stories verfolgt. Der Entwicklungsprozess verläuft in Sprints.

## Funktionsweise

- Schreiben Sie Ihr Problem in das Textfeld und klicken Sie auf **Lösung**. 
- Das Feld wird geleert und eine Nachricht erscheint: *"Ihr Problem wurde als furzig unbedeutend eingestuft. Keine Lösung nötig."*.
- Nichts geht verloren — jedes Problem wird im Hintergrund gespeichert, und Sie können Ihren Verlauf jederzeit über **Meine bisherigen Sorgen** einsehen.

## Funktionen

- 🌍 3 Sprachen: Türkisch, Englisch, Deutsch
- 📝 Verlauf mit Zeitstempel für jeden Eintrag
- 🔒 Benutzerspezifische Speicherung — Probleme werden unter `%APPDATA%\OsuruktanDertButton\complaints.txt` gespeichert, sodass das Teilen der App niemals Ihre Daten weitergibt
- 🗑️ Verlauf mit einem Klick löschen

## Tech-Stack

- **C# / .NET 8**
- **Windows Forms (Winforms)**

## Ausführen

- Repository klonen.
- `OsuruktanDertButton.csproj` in Visual Studio öffnen (.NET 8 SDK erforderlich).
- `F5` drücken.

## Lizenz

Noch nicht festgelegt.