token=mytoken
path=$USERPROFILE/.upmconfig.toml

unameOut="$(uname -s)"
case "${unameOut}" in
    Darwin*)    path=$HOME/.upmconfig.toml;;
esac

echo ${path}

echo "[scopedRegistries]" > ${path}
echo "[scopedRegistries.github]" >> ${path}
echo "name = \"My GitHub Packages\"" >> ${path}
echo "url = \"https://github.com/anhkhoi-unity/PrivateUnityPackage.git\"" >> ${path}
echo "scopes = [\"com.mycompany.helloworld\"]" >> ${path}
