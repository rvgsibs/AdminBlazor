window.onload = function () {
    if ('serviceWorker' in navigator) {
        navigator.serviceWorker.register('sw.js').then(function () {
            console.log('Service Worker Registered');
        });
    }
    let deferredPrompt;
    const addBtn = document.querySelector('#enable-banner-install');

    window.addEventListener('beforeinstallprompt', (e) => {
        console.log('beforeinstallprompt...');
        addBtn.style.display = 'block';
        e.preventDefault();
        deferredPrompt = e;
        addBtn.addEventListener('click', (e) => {
            addBtn.style.display = 'none';
            deferredPrompt.prompt();
            deferredPrompt.userChoice.then((choiceResult) => {
                if (choiceResult.outcome === 'accepted') {
                    console.log('User accepted the prompt');

                } else {
                    console.log('User dismissed the prompt');
                }
                deferredPrompt = null;
            });
        });
    });

};