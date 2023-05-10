/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./index.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        'primary': "#0A4D68",
        'secondary': "#088395",
        'mono-primary': "#e5e7eb",
        'mono-secondary': "#6b7280",
        "accent-primary": "#05BFDB",
        "accent-secondary": "#00FFCA",
        'dark-primary': "#1A1A1B",
        'dark-secondary': "#333F44",
        'dark-accent-primary': "#37AA9C",
        'dark-accent-secondary': "#94F3E4",
        'dark-text-primary': "#bbbbbd",
      }
    },
  },
  plugins: [],
  darkMode: 'class'
}