/// <reference path="node_modules/systemjs/dist/system.js" />
/// <binding ProjectOpened='default' />

var gulp = require("gulp");
var concat = require("gulp-concat");
var concatCss = require("gulp-concat-css");
var less = require("gulp-less");
var minifyCss = require("gulp-minify-css");
var rename = require("gulp-rename");
var tslint = require("gulp-tslint");
var ts = require("gulp-typescript");
var sourcemaps = require("gulp-sourcemaps");
var uglify = require("gulp-uglify");

var BuildTasks = function (globalOptions) {
    var self = this;

    this.tasks = function () {
        this.watchThenRun = function (taskOptions) {
            return function () {
                gulp.watch(taskOptions.inputPaths, [taskOptions.runTaskName]);
            };
        };

        this.compileLess = function (taskOptions) {
            var outputFolder = taskOptions.outputFolder ? taskOptions.outputFolder : globalOptions.outputFolder;

            return function () {
                return gulp.src(taskOptions.inputPaths)
                    .pipe(sourcemaps.init())
                    .pipe(less({
                        filename: taskOptions.outputFileName
                    }))
                    .pipe(sourcemaps.write(".", { sourceRoot: "." }))
                    .pipe(gulp.dest(outputFolder));
            }
        };

        this.concatenateCSS = function (taskOptions) {
            var outputFolder = taskOptions.outputFolder ? taskOptions.outputFolder : globalOptions.outputFolder;

            return function () {
                return gulp.src(taskOptions.inputPaths, { base: outputFolder })
                    .pipe(concatCss(taskOptions.outputFileName))
                    .pipe(gulp.dest(outputFolder));
            };
        };

        this.minifyCSS = function (taskOptions) {
            var outputFolder = taskOptions.outputFolder ? taskOptions.outputFolder : globalOptions.outputFolder;

            return function () {
                gulp.src(taskOptions.inputPaths, { base: outputFolder })
                    .pipe(sourcemaps.init())
                    .pipe(minifyCss())
                    .pipe(rename(function (path) {
                        path.extname = ".min.css";
                    }))
                    .pipe(sourcemaps.write(".", { sourceRoot: "." }))
                    .pipe(gulp.dest(outputFolder));
            };
        };

        this.lintTS = function (taskOptions) {
            return function () {
                return gulp.src(taskOptions.inputPaths)
                    .pipe(tslint({
                        formatter: "prose"
                    }))
                    .pipe(tslint.report({
                        emitError: false
                    }))
            };
        };

        this.compileTS = function (taskOptions) {
            var tsProject = ts.createProject(taskOptions.tsConfigFilePath, {
                outFile: taskOptions.outputFileName
            });

            var outputFolder = taskOptions.outputFolder ? taskOptions.outputFolder : globalOptions.outputFolder;

            return function () {
                return tsProject.src()
                    .pipe(ts(tsProject))
                    .js
                    .pipe(gulp.dest(outputFolder));
            };
        };

        this.minifyJS = function (taskOptions) {
            var outputFolder = taskOptions.outputFolder ? taskOptions.outputFolder : globalOptions.outputFolder;

            return function () {
                return gulp.src(taskOptions.inputPaths)
                    .pipe(sourcemaps.init())
                    .pipe(uglify())
                    .pipe(rename(function (path) {
                        path.extname = ".min.js";
                    }))
                    .pipe(sourcemaps.write(".", { sourceRoot: "." }))
                    .pipe(gulp.dest(outputFolder));
            };
        };

        this.concatenateJS = function (taskOptions) {
            return function () {
                return gulp.src(taskOptions.inputPaths)
                    .pipe(sourcemaps.init())
                    .pipe(concat(taskOptions.outputFileName))
                    .pipe(sourcemaps.write(".", { sourceRoot: "." }))
                    .pipe(gulp.dest(taskOptions.outputFolder ? taskOptions.outputFolder : globalOptions.outputFolder));
            }
        };

        return this;
    }();

    this.initializeStyleWorkflow = function (workflowOptions) {
        var outputFolder = workflowOptions.outputFolder ? workflowOptions.outputFolder : globalOptions.outputFolder;

        gulp.task("compile:less", self.tasks.compileLess({
            inputPaths: workflowOptions.lessInputPaths,
            outputFileName: workflowOptions.compiledLessOutputFileName,
            outputFolder: outputFolder
        }));

        gulp.task("watch:less", self.tasks.watchThenRun({
            inputPaths: workflowOptions.lessWatchPaths,
            runTaskName: "compile:less"
        }));

        gulp.task("concat:lib:css", self.tasks.concatenateCSS({
            inputPaths: workflowOptions.libCssFiles,
            outputFileName: workflowOptions.libOutputFileName,
            outputFolder: outputFolder
        }));

        gulp.task("min:css", ["compile:less", "concat:lib:css"], self.tasks.minifyCSS({
            inputPaths: [
                outputFolder + "/" + workflowOptions.compiledLessOutputFileName,
                outputFolder + "/" + workflowOptions.libOutputFileName
            ]
        }));
    };

    this.initializeTypeScriptWorkflow = function (workflowOptions) {
        var outputFolder = workflowOptions.outputFolder ? workflowOptions.outputFolder : globalOptions.outputFolder;

        gulp.task("lint:ts", self.tasks.lintTS({
            inputPaths: workflowOptions.tsInputPaths
        }));

        gulp.task("compile:ts", ["lint:ts"], self.tasks.compileTS({
            tsConfigFilePath: workflowOptions.tsConfigFilePath,
            outputFileName: workflowOptions.compiledTsOutputFileName,
            outputFolder: outputFolder
        }));

        gulp.task("watch:ts", self.tasks.watchThenRun({
            inputPaths: workflowOptions.tsInputPaths,
            runTaskName: "compile:ts"
        }));

        gulp.task("concat:lib:js", self.tasks.concatenateJS({
            inputPaths: workflowOptions.libInputPaths,
            outputFileName: workflowOptions.libOutputFileName,
            outputFolder: outputFolder
        }));

        gulp.task("min:js", ["concat:lib:js", "compile:ts"], self.tasks.minifyJS({
            inputPaths: [
                outputFolder + "/" + workflowOptions.compiledTsOutputFileName,
                outputFolder + "/" + workflowOptions.libOutputFileName
            ],
            outputFolder: outputFolder
        }));
    };
};

var buildTasks = new BuildTasks({
    outputFolder: "wwwroot"
});

buildTasks.initializeStyleWorkflow({
    outputFolder: "wwwroot/css",
    lessInputPaths: "Styles/site.less",
    lessWatchPaths: [
        "Styles/*.less",
        "node_modules/bootstrap/less/*.less",
        "node_modules/bootstrap/less/mixins/*.less"
    ],
    compiledLessOutputFileName: "site.css",
    libCssFiles: [
        "node_modules/angular-toastr/dist/angular-toastr.css",
        "node_modules/angular-tablesort/tablesort.css"
    ],
    libOutputFileName: "lib.css"
});

buildTasks.initializeTypeScriptWorkflow({
    outputFolder: "wwwroot/js",
    tsInputPaths: "Scripts/app/**/*.ts",
    tsWatchPaths: "Scripts/app/**/*.ts",
    tsConfigFilePath: "tsconfig.json",
    compiledTsOutputFileName: "app.js",
    libInputPaths: [
        "node_modules/jquery/dist/jquery.js",
        "node_modules/bootstrap/dist/js/bootstrap.js",
        "node_modules/lodash/lodash.js",
        "node_modules/angular/angular.js",
        "node_modules/angular-ui-bootstrap/dist/ui-bootstrap.js",
        "node_modules/angular-ui-bootstrap/dist/ui-bootstrap-tpls.js",
        "node_modules/angular-ui-router/release/angular-ui-router.js",
        "node_modules/angular-ui-router-uib-modal/src/angular-ui-router-uib-modal.js",
        "node_modules/systemjs/dist/system.js",
        "node_modules/systemjs/dist/system-polyfills.js",
        "node_modules/angular-toastr/dist/angular-toastr.tpls.js",
        "node_modules/angular-tablesort/js/angular-tablesort.js",
        "node_modules/es6-shim/es6-shim.js"
    ],
    libOutputFileName: "lib.js"
});

gulp.task("watch", ["watch:less", "watch:ts"]);
gulp.task("publish", ["min:css", "min:js"]);
gulp.task("default", ["publish"]);