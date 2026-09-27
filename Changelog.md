# Changelog

Bu projedeki önemli değişiklikler bu dosyada tutulur. Format [Keep a Changelog](https://keepachangelog.com/tr-TR/1.1.0/) standardına, versiyon numaraları [Semantic Versioning](https://semver.org/lang/tr/) kurallarına dayanmaktadır.

## [Unreleased]

### Added
- Dertler listesinden tek bir derdi seçip silme butonu ve işlevi
- Changelog.md eklendi

## [1.0.0] - 2026-09-26
- Temel arayüz: dert yazma kutusu, "Çözüm" butonu
- 3 dil desteği: Türkçe, English, Deutsch
- Dert geçmişi: kayıt, görüntüleme, tümünü temizleme ("Önceki Dertlerim" penceresi)
- Kullanıcı özel depolama (`%APPDATA%\OsuruktanDertButton\complaints.txt`)
- Tema sistemi: 2000'ler Klasik, Karanlık, Aydınlık (canlı geçiş, kalıcı tercih yapısı)
- Özel çizilmiş, animasyonlu yuvarlak "Çözüm" butonu (BigRedButton)
- Uygulama ikonu
- Inno Setup ile kurulum sihirbazı (masaüstü kısayolu, Başlat menüsü, kaldırma desteği, çok dilli kurulum ekranı)
- Enter tuşu ile "Çözüm" butpnu tetikleme (Shift+Enter / Ctrl+Enter ile çok satırlı yazım desteği)
- Versiyonlama altyapısı (`.csproj` sürüm bilgisi, pencere başlığında görüntüleme)

[Unreleased]: https://github.com/SatanJager/OsuruktanDertButton/compare/tag/v1.0.0...HEAD
[1.0.0]: https://github.com/SatanJager/OsuruktanDertButton/releases/tag/v1.0.0