/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp'),
    watch = require('gulp-watch'),
    jshint = require('gulp-jshint');

gulp.task('linter', function () {
    var fileGlob = 'app/**/*.js';
    return gulp.src(fileGlob)
      .pipe(watch(fileGlob))
      .pipe(jshint())
      .pipe(jshint.reporter('default'));
});

gulp.task('default', function () {
    // place code for your default task here
});