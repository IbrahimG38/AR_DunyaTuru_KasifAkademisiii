# INSTALLATION.md

## Sistem Gereksinimleri

- Unity 2022.3 LTS veya üzeri
- AR Foundation (4.2.0 veya üstü)
- Android Build Support (Unity Hub üzerinden eklenmeli)
- Android cihaz (Android 8.0 veya üzeri önerilir)

## Kurulum Adımları

1. Unity Hub üzerinden projeyi açın.
2. Gerekli paketleri `Window > Package Manager` üzerinden kontrol edin:
   - AR Foundation
   - ARCore XR Plugin
3. `File > Build Settings > Android` seçin ve "Switch Platform" butonuna tıklayın.
4. `Player Settings` kısmında:
   - **Package Name** kısmını doldurun (örnek: com.firma.ardunyaturu)
   - **Minimum API Level**: Android 8.0 (API Level 26) veya üzeri seçin.
   - **Active Input Handling**: Input Manager (old) veya Input System (new) seçin.
5. `XR Plug-in Management` ayarlarından Android sekmesinde ARCore kutucuğunu işaretleyin.
6. `Scenes In Build` kısmına sahnenizin eklendiğinden emin olun.
7. Cihazınızı USB ile bağlayın ve "Build and Run" yapın.

## Troubleshooting

- **Siyah ekran görünüyor:** AR destekli cihaz kullanmıyor olabilirsiniz.
- **Model görünmüyor:** Görselin net ve iyi ışık altında olduğundan emin olun.
- **Uygulama aniden kapanıyor:** Konsol hatalarını kontrol edin, `PlayerSettings > Input Handling` ayarını düzeltin.