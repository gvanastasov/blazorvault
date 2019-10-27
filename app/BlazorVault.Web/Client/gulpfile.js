const gulp = require('gulp');
const sass = require('gulp-sass');
const del = require('del');
const bs = require('browser-sync').create();

function browserSync(done) {
    bs.init({
        proxy: "http://localhost:61406/",
        files: [
            'wwwroot/**/*'
        ]
    });
    done();
};

function css() {
    return gulp
        .src('src/site.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('./wwwroot/css/'))
        .pipe(bs.stream());
};

function watchFiles() {
    gulp.watch("./src/**/*.scss", css);
}

function clean() {
    return del(['wwwroot/css/site.css']);
};

// gulp.task('default', gulp.series(['clean', 'css']));

const watch = gulp.parallel(watchFiles, browserSync);

exports.watch = watch;