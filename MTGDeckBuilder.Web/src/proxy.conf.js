const PROXY_CONFIG = [
  {
    context: [
      "/mtgsearch/*",
    ],
    target: "https://localhost:5001",
    secure: false    
  }
]

module.exports = PROXY_CONFIG;
