const PROXY_CONFIG = [
  {
    context: [
      "/mtgsearch/*",
      "/deckbuilder/*"
    ],
    target: "https://localhost:5001",
    secure: false    
  }
]

module.exports = PROXY_CONFIG;
