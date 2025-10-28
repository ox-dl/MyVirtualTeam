// Select all sections, links & root container
const sections = document.querySelectorAll('main section[id]');
const navLinks = document.querySelectorAll('.page-nav a');
const root = document.querySelector('#container');

// Create the IntersectionObserver
const observer = new IntersectionObserver(entries => {
  entries.forEach(entry => {
    const id = entry.target.getAttribute('id');
    const link = document.querySelector(`.page-nav a[href="#${id}"]`);
    // If the section is visible
    if (entry.isIntersecting) {
      navLinks.forEach(l => l.classList.remove('page-nav--actived'));
      link.classList.add('page-nav--actived');
      // Update the URL without reloading
      history.replaceState(null, '', `#${id}`);
    }
  });
}, {
  root: root,
  // Adjust when a section is considered "in view"
  rootMargin: '-100px 0px -300px 0px',
  // At least 50% of the section must be visible
  threshold: 0.5
});

// Start observing each section
sections.forEach(section => observer.observe(section));