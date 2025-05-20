
# MobileProviderGateway

The **MobileProviderGateway** serves as a centralized API Gateway for the Mobile Provider ecosystem, facilitating secure and efficient routing of client requests to the appropriate backend services.

### You can test it here: On [Render](https://mobileproviderchatapp.onrender.com)

## 🔗 Related Projects

- **Backend API**: [MobileProviderAPI](https://github.com/Sehrank8/MobileProviderAPI)
- **Chatbot**: [MobileProviderChatBot](https://github.com/Sehrank8/MobileProviderChatBot)
- **Frontend Application**: [MobileProviderChatApp](https://github.com/Sehrank8/MobileProviderChatApp)

## 🚀 Features

- **Centralized Routing** using Ocelot
- **JWT-based Authentication**
- **Logging & Monitoring**
- **Dockerized Deployment**

## 🛠️ Technologies Used

- .NET Core
- Ocelot
- Docker
- JWT

## 📁 Project Structure

```
MobileProviderGateway/
├── ocelot.json
├── Program.cs
├── Startup.cs
├── Dockerfile
├── appsettings.json
└── ...
```

## ⚙️ Getting Started

### Prerequisites

- .NET Core SDK 3.1 or later
- Docker (optional)

### Installation

```bash
git clone https://github.com/Sehrank8/MobileProviderGateway.git
cd MobileProviderGateway
dotnet restore
dotnet build
dotnet run
```

### Docker Deployment

```bash
docker build -t mobileprovidergateway .
docker run -d -p 5000:5000 mobileprovidergateway
```

## 🔧 Configuration

Example `ocelot.json` routing:

```json
{
  "Routes": [
    {
      "DownstreamPathTemplate": "/api/{everything}",
      "DownstreamScheme": "http",
      "DownstreamHostAndPorts": [
        { "Host": "localhost", "Port": 5001 }
      ],
      "UpstreamPathTemplate": "/gateway/{everything}",
      "UpstreamHttpMethod": [ "GET", "POST", "PUT", "DELETE" ],
      "AuthenticationOptions": {
        "AuthenticationProviderKey": "Bearer",
        "AllowedScopes": []
      }
    }
  ],
  "GlobalConfiguration": {
    "BaseUrl": "http://localhost:5000"
  }
}
```

## 🔐 Security

- JWT-based Authorization
- HTTPS support via reverse proxy

## 📈 Monitoring & Logging

- .NET Core structured logging
- Optional integration with health checks and Prometheus

## 🧪 Testing

```bash
curl -H "Authorization: Bearer <token>" http://localhost:5000/gateway/endpoint
```
