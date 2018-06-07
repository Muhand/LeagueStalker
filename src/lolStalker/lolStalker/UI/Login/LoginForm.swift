//
//  LoginForm.swift
//  lolStalker
//
//  Created by Muhand Jumah on 6/1/18.
//  Copyright © 2018 Muhand Jumah. All rights reserved.
//

import Foundation
import UIKit

protocol loginFormDelegate {
    func didPressLogin(form: LoginForm)
    func didPressSignup(form: LoginForm)
    func didPressForgotPassword(form: LoginForm)
}

class LoginForm: UIView {
    ////////////////////////////////////
    //            Delegates
    ////////////////////////////////////
    var delegate: loginFormDelegate?

    ////////////////////////////////////
    //            Gestures
    ////////////////////////////////////
    var forgotPasswordTapped:UITapGestureRecognizer!
    
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
    let logo: UIImageView = {
        let image = UIImageView()
        image.image = UIImage(named: "logo")
        image.contentMode = .scaleAspectFit
        image.layer.masksToBounds = true
        image.frame.size = CGSize(width: Helper.getWidthOf(xdWidth: 208, referenceWidth: nil, originalWidth: nil), height: Helper.getHeightOf(xdHeight: 84, referenceHeight: nil, originalHeight: nil))
        return image
    }()
    
    let emailField: TextField = {
        let field = TextField()
        field.backgroundColor = UIColor(hex: "#0D161F")
        field.attributedPlaceholder = NSAttributedString(string: "Email", attributes: [NSAttributedStringKey.foregroundColor: UIColor(hex: "#95989A") ?? UIColor.lightGray])
        field.layer.borderWidth = Helper.getWidthOf(xdWidth: 1.0, referenceWidth: nil, originalWidth: nil)
        field.borderColor = UIColor(hex: "#95989A")!
        field.borderColorOnSelected = UIColor(hex: "#CE9340")!
        field.textColor = UIColor(hex: "#95989A")
        field.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 20, referenceHeight: nil, referenceWidth: nil))
        
        var topBottomPadding = Helper.getWidthOf(xdWidth: 13, referenceWidth: nil, originalWidth: nil)
        var leftRightPadding = Helper.getWidthOf(xdWidth: 21, referenceWidth: nil, originalWidth: nil)
        
        field.padding = UIEdgeInsets(top: topBottomPadding, left: leftRightPadding, bottom: topBottomPadding, right: leftRightPadding)
        
        return field
    }()
    
    let passwordField: TextField = {
        let field = TextField()
        field.backgroundColor = UIColor(hex: "#0D161F")
        field.attributedPlaceholder = NSAttributedString(string: "Password", attributes: [NSAttributedStringKey.foregroundColor: UIColor(hex: "#95989A") ?? UIColor.lightGray])
        field.isSecureTextEntry = true
        field.layer.borderWidth = Helper.getWidthOf(xdWidth: 1.0, referenceWidth: nil, originalWidth: nil)
        field.borderColor = UIColor(hex: "#95989A")!
        field.borderColorOnSelected = UIColor(hex: "#CE9340")!
        field.textColor = UIColor(hex: "#95989A")
        field.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 20, referenceHeight: nil, referenceWidth: nil))

        var topBottomPadding = Helper.getWidthOf(xdWidth: 13, referenceWidth: nil, originalWidth: nil)
        var leftRightPadding = Helper.getWidthOf(xdWidth: 21, referenceWidth: nil, originalWidth: nil)
        
        field.padding = UIEdgeInsets(top: topBottomPadding, left: leftRightPadding, bottom: topBottomPadding, right: leftRightPadding)

        return field
    }()
    
    let loginButton: UIButton = {
        let button = UIButton()
        button.setBackgroundColor(color: UIColor(hex: "#010A13")!, forState: .normal)
        button.setBackgroundColor(color: UIColor(hex: "#CE9340")!, forState: .highlighted)
        button.setTitleColor(UIColor(hex: "#CE9340"), for: .normal)
        button.setTitleColor(UIColor(hex: "#010A13"), for: .highlighted)
        button.setTitle("LOGIN", for: .normal)
        button.layer.borderWidth = Helper.getWidthOf(xdWidth: 1.0, referenceWidth: nil, originalWidth: nil)
        button.layer.borderColor = UIColor(hex: "#CE9340")?.cgColor
        button.titleLabel?.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 32, referenceHeight: nil, referenceWidth: nil))
        
        button.addTarget(self, action: #selector(loginPressed(sender:)), for: .touchUpInside)
        return button
    }()
    
    let signupButton: UIButton = {
        let button = UIButton()
        button.setBackgroundColor(color: UIColor(hex: "#010A13")!, forState: .normal)
        button.setBackgroundColor(color: UIColor(hex: "#CE9340")!, forState: .highlighted)
        button.setTitleColor(UIColor(hex: "#CE9340"), for: .normal)
        button.setTitleColor(UIColor(hex: "#010A13"), for: .highlighted)
        button.setTitle("SIGN UP", for: .normal)
        button.layer.borderWidth = Helper.getWidthOf(xdWidth: 1.0, referenceWidth: nil, originalWidth: nil)
        button.layer.borderColor = UIColor(hex: "#CE9340")?.cgColor
        button.titleLabel?.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 32, referenceHeight: nil, referenceWidth: nil))
        
        button.addTarget(self, action: #selector(signupPressed(sender:)), for: .touchUpInside)
        return button
    }()
    
    let forgotPasswordLabel: UILabel = {
        let label = UILabel()
        label.text = "Forgot password?"
        label.textColor = UIColor(hex: "#95989A")
        label.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 20, referenceHeight: nil, referenceWidth: nil))
//        label.isUserInteractionEnabled = true
        return label
    }()
    
    ////////// END OF CONTROLS /////////
    
    override init(frame: CGRect) {
        super.init(frame: frame)
        setupGestures()
        setupView()
        setupConstraints()
    }
    
    required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
    
    func setupView() {
        // TODO: Delete the next line, it's helpful only in debug
//        self.backgroundColor = UIColor.yellow
        
//        self.frame.size = CGSize(width: UIScreen.main.bounds.width-32, height: ((UIScreen.main.bounds.height*68.3658170915)/100))
        
//        NSLayoutConstraint(item: form, attribute: .left, relatedBy: <#T##NSLayoutRelation#>, toItem: <#T##Any?#>, attribute: <#T##NSLayoutAttribute#>, multiplier: <#T##CGFloat#>, constant: <#T##CGFloat#>)
//        self.addConstraintsWithFormat(format: "H:|-32-[v0]-32-|", views: form)
//        self.addConstraintsWithFormat(format: "V:|[v0]|", views: form)
//        self.addConstraintsWithFormat(format: <#T##String#>, views: <#T##UIView...##UIView#>)
    }
    
    func setupGestures() {
        // Enable user interaction
        forgotPasswordLabel.isUserInteractionEnabled = true
        
        // Set gestures
        self.forgotPasswordTapped = UITapGestureRecognizer(target: self, action: #selector(forgotPasswordPressed))
        
        // Add gestures
        forgotPasswordLabel.addGestureRecognizer(forgotPasswordTapped)
    }
    
    func setupConstraints() {
        // MARK: private variables
        let defaultHeight:CGFloat = Helper.getHeightOf(xdHeight: 43, referenceHeight: nil, originalHeight: nil)
        
        // MARK: Add subviews
        addSubview(self.logo)
        addSubview(emailField)
        addSubview(passwordField)
        addSubview(loginButton)
        addSubview(signupButton)
        addSubview(forgotPasswordLabel)
        
        // MARK: Disable frames
        logo.translatesAutoresizingMaskIntoConstraints = false
        emailField.translatesAutoresizingMaskIntoConstraints = false
        passwordField.translatesAutoresizingMaskIntoConstraints = false
        loginButton.translatesAutoresizingMaskIntoConstraints = false
        signupButton.translatesAutoresizingMaskIntoConstraints = false
        forgotPasswordLabel.translatesAutoresizingMaskIntoConstraints = false
        
        // MARK: Constraints
        // LOGO
        logo.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
        logo.topAnchor.constraint(equalTo: topAnchor, constant: Helper.getHeightOf(xdHeight: 15, referenceHeight: nil, originalHeight: nil)).isActive = true
        logo.widthAnchor.constraint(equalToConstant: Helper.getWidthOf(xdWidth: 208, referenceWidth: nil, originalWidth: nil)).isActive = true
        logo.heightAnchor.constraint(equalToConstant: Helper.getHeightOf(xdHeight: 84, referenceHeight: nil, originalHeight: nil)).isActive = true
        
        // EMAIL FIELD
        emailField.topAnchor.constraint(equalTo: logo.bottomAnchor, constant: Helper.getHeightOf(xdHeight: 58, referenceHeight: nil, originalHeight: nil)).isActive = true
        emailField.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
        emailField.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
        emailField.heightAnchor.constraint(equalToConstant: defaultHeight).isActive = true
        
        // PASSWORD FIELD
        passwordField.topAnchor.constraint(equalTo: emailField.bottomAnchor, constant: Helper.getHeightOf(xdHeight: 26, referenceHeight: nil, originalHeight: nil)).isActive = true
        passwordField.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
        passwordField.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
        passwordField.heightAnchor.constraint(equalToConstant: defaultHeight).isActive = true
        
        // LOGIN BUTTON
        loginButton.topAnchor.constraint(equalTo: passwordField.bottomAnchor, constant: Helper.getHeightOf(xdHeight: 58, referenceHeight: nil, originalHeight: nil)).isActive = true
        loginButton.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
        loginButton.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
        loginButton.heightAnchor.constraint(equalToConstant: defaultHeight).isActive = true
        
        // SIGN UP BUTTON
        signupButton.topAnchor.constraint(equalTo: loginButton.bottomAnchor, constant: Helper.getHeightOf(xdHeight: 12, referenceHeight: nil, originalHeight: nil)).isActive = true
        signupButton.centerXAnchor.constraint(equalTo: centerXAnchor).isActive = true
        signupButton.widthAnchor.constraint(equalTo: widthAnchor).isActive = true
        signupButton.heightAnchor.constraint(equalToConstant: defaultHeight).isActive = true
        
        // FORGOT PASSWORD LABEL
        forgotPasswordLabel.topAnchor.constraint(equalTo: signupButton.bottomAnchor, constant: Helper.getHeightOf(xdHeight: 18, referenceHeight: nil, originalHeight: nil)).isActive = true
        forgotPasswordLabel.leftAnchor.constraint(equalTo: leftAnchor).isActive = true
        
//        logo.heightAnchor.constraint(equalTo:heightAnchor, multiplier: 0.683658170915).isActive = true
//        logo.widthAnchor.constraint(equalTo: widthAnchor, constant:-64).isActive = true
//        form.addConstraintsWithFormat(format: "H:|[v0]|", views: self.logo)
//        form.addConstraintsWithFormat(format: "H:|[v0]|", views: self.emailField)
//        form.addConstraintsWithFormat(format: "H:|[v0]|", views: self.passwordField)
//        form.addConstraintsWithFormat(format: "H:|[v0]|", views: self.loginButton)
//        form.addConstraintsWithFormat(format: "H:|[v0]|", views: self.signupButton)
//        form.addConstraintsWithFormat(format: "H:|[v0]|", views: self.forgotPasswordLabel)
//        form.addConstraintsWithFormat(format: "V:|-15-[v0]-26-[v2(\(rectangleHeight))]-59-[v3(\(rectangleHeight))]-12-[v4(\(rectangleHeight))]-18-[v5]", views: self.logo, self.passwordField, self.loginButton, self.signupButton, self.forgotPasswordLabel)
        
        
//        logo.centerXAnchor.constraint(equalTo: form.centerXAnchor).isActive = true
//        emailField.topAnchor.constraint(equalTo: logo.bottomAnchor, constant: 15).isActive = true
//        emailField.centerXAnchor.constraint(equalTo: form.centerXAnchor).isActive = true
//        layoutIfNeeded()
//        emailField.widthAnchor.constraint(equalToConstant: form.frame.width).isActive = true
    }
    
//    @objc func forgotPasswordPressed(recognizer:UITapGestureRecognizer) {
//        if let label = recognizer.view as? UILabel {
//            print("TAPPPED")
//        }
//    }
    ////////////////////////////////////
    //           IBOutlets
    ////////////////////////////////////
    @IBAction func loginPressed(sender: AnyObject) {
        self.delegate?.didPressLogin(form: self)
    }
    
    @IBAction func signupPressed(sender: AnyObject) {
        self.delegate?.didPressSignup(form: self)
    }
    
    @objc func forgotPasswordPressed() {
        self.delegate?.didPressForgotPassword(form: self)
    }
    
}
