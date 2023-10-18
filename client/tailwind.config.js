/** @type {import('tailwindcss').Config} */
const withMT = require("@material-tailwind/react/utils/withMT");
module.exports = withMT({
  content: ["./index.html", "./src/**/*.{js,ts,jsx,tsx}"],
  theme: {
    extend: {
      colors: {
        mainBlueColor: "#247b99",
        linkColor: "#980c28"
      },
      fontSize: {
        xxs: "8px",
      },
    },
  },
  plugins: [],
});