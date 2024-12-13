(function () {
    var baseElement = document.querySelector('base');
    var repoName = 'repository-name'; // Replace with your actual repository name
    var isGithubPages = location.hostname.includes('github.io');

    if (isGithubPages) {
        baseElement.setAttribute('href', '/' + repoName + '/');
    } else {
        baseElement.setAttribute('href', '/');
    }
})();