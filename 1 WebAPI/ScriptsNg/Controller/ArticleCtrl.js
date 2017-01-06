
app.controller('ArticleCtrl', ['$scope', 'CrudService',
    function ($scope, CrudService) {

        // Base Url 
        var baseUrl = '/api/Article/';
        $scope.btnText = "Save";
        $scope.articleID = 0;
        $scope.SaveUpdate = function () {
            debugger
            var article = {

                Nom: $scope.nom,
                Prix: $scope.prix,
                Stock: $scope.stock,
                //categorie
                Identifiant: $scope.identifiant


            }
            if ($scope.btnText == "Save") {
                var apiRoute = baseUrl + 'SaveArticle/';
                var saveArticle = CrudService.post(apiRoute, article);
                
                saveArticle.then(function (response) {
                    if (response.data != "") {
                        alert("Data Save Successfully");
                        $scope.GetArticles();
                        $scope.Clear();

                    } else {
                        alert("Some error");
                    }

                }, function (error) {
                    console.log("Error: " + error);
                });
            }
            else
            {
                var apiRoute = baseUrl + 'UpdateArticle/';
                var UpdateArticle = CrudService.put(apiRoute, article);
                debugger
                UpdateArticle.then(function (response) {
                    if (response.data != "") {
                        alert("miseà jour ok");
                        $scope.GetArticles();
                        $scope.Clear();

                    } else {
                        alert("Erreur");
                    }

                }, function (error) {
                    console.log("Erreur: " + error);
                });
            }
        }


        $scope.GetArticles = function () {
            var apiRoute = baseUrl + 'GetArticles/';
            var article = CrudService.getAll(apiRoute);
            article.then(function (response) {
                debugger
                $scope.articles = response.data;

            },
            function (error) {
                console.log("Erreur: " + error);
            });


        }
        $scope.GetArticles();
        
        $scope.GetArticleByID = function (dataModel)
        {
            debugger
            var apiRoute = baseUrl + 'GetArticleByID';
            var article = CrudService.getbyID(apiRoute, dataModel.Identifiant);
            article.then(function (response) {



                $scope.identifiant = response.data.Identifiant;
                $scope.nom = response.data.Nom;
                $scope.prix = response.data.Prix;
                $scope.stock = response.data.Stock;
                $scope.btnText = "Update";
                debugger

            },
            function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.DeleteArticle = function (dataModel)
        {
            debugger
            var apiRoute = baseUrl + 'DeleteArticle/' + dataModel.Identifiant;
            var deleteArticle = CrudService.delete(apiRoute);
            deleteArticle.then(function (response) {
                if (response.data != "") {
                    alert("Article supprimé");
                    $scope.GetArticles();
                    $scope.Clear();

                } else {
                    alert("erreur");
                }

            }, function (error) {
                console.log("Erreur: " + error);
            });
        }

        $scope.Clear = function () {
            $scope.identifiant = 0;
            $scope.firstName = "";
            $scope.lasttName = "";
            $scope.email = "";
            $scope.adress = "";
            $scope.btnText = "Save";
        }

    }]);