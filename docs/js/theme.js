document.addEventListener("DOMContentLoaded", () => {

  // Detect Button & Image elements
  const themeBtn = document.querySelector('button.theme');
  const themeIcon = document.getElementById('themeIcon');

  // Apply and save a selected theme
  const applyTheme = theme => {
    document.documentElement.setAttribute('data-theme', theme);
    localStorage.setItem('theme', theme);

    // Update the theme icon
    if (theme === 'dark') {
      themeIcon.src = './img/Theme_Sun.png';
      themeIcon.alt = 'Sun icon';
    } else {
      themeIcon.src = './img/Theme_Moon.png';
      themeIcon.alt = 'Moon icon';
    }
  };

  // Detect if a theme is already actived
  const userTheme = localStorage.getItem('theme');
  if (userTheme) {
    applyTheme(userTheme);
  } else {
    const darkModeDetected = window.matchMedia('(prefers-color-scheme: dark)').matches;
    applyTheme(darkModeDetected ? 'dark' : 'light');
  }

  // Toggle theme on button click
  themeBtn.addEventListener("click", () => {
    const currentTheme = document.documentElement.getAttribute('data-theme');
    applyTheme(currentTheme === 'dark' ? 'light' : 'dark');
  });

});