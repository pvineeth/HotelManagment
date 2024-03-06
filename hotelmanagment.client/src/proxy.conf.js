const PROXY_CONFIG = [
  {
    context: [
      "/api/Authentication/Login"
    ],
    target: "https://localhost:7094",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
