# <a id="turkce"></a>BlazorTicTacToe
[Read in English](#english) <br/><br/>
BlazorTicTacToe, SignalR'nin Blazor ile entegrasyonunu gösteren bir demo projesidir. Bu proje, tarayıcıda oynanabilen, gerçek zamanlı, etkileşimli bir X O X oyununun nasıl inşa edileceğini göstermektedir. Proje, üç ana bölümden oluşur: sunucu, istemci ve paylaşılan kütüphaneler.

### İçindekiler
* Proje Yapısı
* Özellikler
* Kullanılan Teknolojiler
* Başlarken
* Uygulamanın Çalıştırılması
* Katkıda Bulunma
* Lisans

## Proje Yapısı
Çözüm üç projeden oluşmaktadır:

#### 1. BlazorTicTacToe:

* Hubs: SignalR kullanarak sunucu ile istemciler arasında gerçek zamanlı iletişimi yöneten GameHub.cs dosyasını içerir.
* Components: Uygulama genelinde kullanılan paylaşılan bileşenleri barındırır.
* wwwroot: Statik dosyaları içerir.
* Program.cs: Sunucu için web sunucusunu yapılandırır.
  
#### 2. BlazorTicTacToe.Client:

* Components: Blazor bileşenlerini içerir, Room.razor ana oyun odası kullanıcı arayüzüdür.
* Pages: İstemci tarafındaki kullanıcı arayüzünü tanımlayan Blazor sayfaları.
* wwwroot: İstemciye özel statik dosyalar.
* Program.cs: Blazor WebAssembly istemci uygulamasını yapılandırır.
  
#### 3. BlazorTicTacToe.Shared:

* GameRoom.cs: Oyun odası yapısını ve durumunu tanımlar.
* Player.cs: Oyundaki oyuncu varlıklarını temsil eder.
* TicTacToeGame.cs: Oyuncu sıraları ve oyun durumu dahil olmak üzere X O X oyununu yönetme mantığını içerir.

## Özellikler
* Gerçek Zamanlı İletişim: SignalR kullanarak istemciler ve sunucu arasında gerçek zamanlı, çift yönlü iletişim sağlar.
* Blazor Entegrasyonu: Blazor'un dinamik, etkileşimli web kullanıcı arayüzleri oluşturma yeteneklerini gösterir.
* Oyun Mantığı: Birden fazla oyuncu ile X O X oyun mantığını uygular.

## Kullanılan Teknolojiler
* Blazor: C# ile etkileşimli web kullanıcı arayüzleri oluşturmak için bir çerçeve.
* SignalR: Uygulamalara gerçek zamanlı web işlevselliği eklemek için bir kütüphane.
* .NET Core: Sunucunun inşa edildiği platform.

## Başlarken
Gereksinimler
* .NET 6 SDK
* Visual Studio veya Visual Studio Code

## Kurulum
#### 1. Depoyu klonlayın:
```
git clone https://github.com/goktugsenkal/BlazorTicTacToe.git
cd BlazorTicTacToe
```
#### 2. Çözümü Visual Studio veya tercih ettiğiniz editörde açın.

#### 3. NuGet paketlerini geri yükleyin:
```
dotnet restore
```

## Uygulamanın Çalıştırılması
#### 1. BlazorTicTacToe/BlazorTicTacToe/BlazorTicTacToe dizinine gidin.
###### İlk dizin github deposunun dosyası, 2. dizin çözüm'ün(solution) kendisi, 3. dizin ise sunucu projesidir.
#### 2. Projeyi komple ayağa kaldırmak için şu komutu çalıştırın: 
```
dotnet run
```

## Uygulamaya Erişim
* Tarayıcınızı açın ve http://localhost:<port> adresine gidin (burada <port>, sunucunun çalıştığı port numarasıdır).
* Birden fazla tarayıcı sekmesi açarak çok oyunculu deneyimi test edebilirsiniz.
* Uzaktaki istemcilerle bağlantı kurmak için Microsoft'un port yönlendirme özelliğini kullanabilirsiniz.

## Katkıda Bulunma
Katkılar memnuniyetle kabul edilir! Lütfen depoyu çatallayın ve değişikliklerinizi içeren bir çekme isteği gönderin.

## Lisans
Bu proje MIT Lisansı altında lisanslanmıştır. Ayrıntılar için [LICENSE](https://opensource.org/licenses/MIT) dosyasına bakın.

# <a id="english"></a>BlazorTicTacToe
[Türkçe Oku](#turkce)<br/><br/>
BlazorTicTacToe is a demo project showcasing the integration of SignalR with Blazor. This project demonstrates how to build a real-time, interactive Tic-Tac-Toe game that can be played in a browser. The project is structured into three main parts: the server, client, and shared libraries.

## Table of Contents
* Project Structure
* Features
* Technologies Used
* Getting Started
* Running the Application
* Contributing
* License

## Project Structure
The solution consists of three projects:

#### 1. BlazorTicTacToe:

* Hubs: Contains the GameHub.cs file which manages real-time communication between the server and clients using SignalR.
* Components: Houses shared components used across the application.
* wwwroot: Contains static assets.
* Program.cs: Configures the web host for the server.
  
#### 2. BlazorTicTacToe.Client:

* Components: Contains Blazor components, including Room.razor, which is the main game room UI.
* Pages: Blazor pages that define the client-side UI.
* wwwroot: Client-specific static assets.
* Program.cs: Sets up the Blazor WebAssembly client application.
  
#### 3. BlazorTicTacToe.Shared:

* GameRoom.cs: Defines the game room structure and state.
* Player.cs: Represents player entities in the game.
* TicTacToeGame.cs: Contains the logic for managing the Tic-Tac-Toe game, including player turns and game state.

## Features
* Real-Time Communication: Utilizes SignalR to enable real-time, bi-directional communication between clients and the server.
* Blazor Integration: Demonstrates the use of Blazor for building dynamic, interactive web UIs.
* Game Logic: Implements the Tic-Tac-Toe game logic with multiple players.
  
## Technologies Used
* Blazor: A framework for building interactive web UIs with C#.
* SignalR: A library for adding real-time web functionality to applications.
* .NET Core: The platform on which the server is built.
  
## Getting Started
Prerequisites
* .NET 6 SDK
* Visual Studio or Visual Studio Code
  
## Installation
#### 1. Clone the repository:
```
git clone https://github.com/goktugsenkal/BlazorTicTacToe.git
cd BlazorTicTacToe
```
#### 2. Open the solution in Visual Studio or your preferred editor.

#### 3. Restore the NuGet packages:
```
dotnet restore
```
## Running the Application
#### 1. Navigate to the BlazorTicTacToe/BlazorTicTacToe/BlazorTicTacToe directory.
###### The first directory is the GitHub repository folder, the second is the solution itself, and the third is the server project.
#### 2. Run the entire project with the following command: 
```
dotnet run
```

## Accessing the Application
* Open your browser and navigate to http://localhost:<port> (where <port> is the port number on which the server is running).
* You can test multiplayer by opening multiple browser tabs.
* Use Microsoft's port forwarding feature to connect with remote clients.
  
## Contributing
Contributions are welcome! Please fork the repository and submit a pull request with your changes.

## License
This project is licensed under the MIT License. See the [LICENSE](https://opensource.org/licenses/MIT) file for details.
